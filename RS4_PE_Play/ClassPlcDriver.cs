using System;
using System.Reflection;
using System.Threading;
using ResisterTest.Managers;

namespace WindowsFormsApp1
{
    public interface IPlcDriver : IDisposable
    {
        bool IsConnected { get; }
        bool Connect();
        void Disconnect();
        bool ReadWords(int startAddress, int count);
        bool WriteWords(int startAddress, int count);
        bool WriteBitWords(int startAddress, ushort[] data);
    }


    // 미쓰비시 MX Component 이더넷 방식 (동적 COM - MX Component 4 필요)
    public class MelsecMxDriver : IPlcDriver
    {
        private readonly string _ipAddress;
        private readonly int _port;
        private object _plc;
        private Type _plcType;
        private bool _connected;

        public bool IsConnected => _connected;

        // MX Component 4 표준 CPU 타입
        // Q04UDEHCPU = 210 (0xD2), Q06UDEHCPU = 211
        private const int CPU_TYPE_Q04UDEH = 210;
        private const int MELSEC_PORT = 5001;

        public MelsecMxDriver(string ipAddress, int port = MELSEC_PORT)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public bool Connect()
        {
            try
            {
                // MX Component 4 COM ProgID 시도 순서
                string[] progIds = {
                    "ACTEtherLib.ActQNUDECPUTCP",
                    "ActProgTypeLib.ActProgType1",
                    "ACT.ActQNUDECPUTCP"
                };

                foreach (var progId in progIds)
                {
                    _plcType = Type.GetTypeFromProgID(progId);
                    if (_plcType != null) break;
                }

                if (_plcType == null)
                {
                    Logger.Log("[MX] MX Component가 설치되어 있지 않습니다.");
                    return false;
                }

                _plc = Activator.CreateInstance(_plcType);
                SetProp("ActHostAddress", _ipAddress);
                SetProp("ActPortNumber", _port);
                SetProp("ActCpuType", CPU_TYPE_Q04UDEH);
                SetProp("ActTimeOut", 3000);

                int ret = (int)_plcType.InvokeMember("Open",
                    BindingFlags.InvokeMethod, null, _plc, null);
                _connected = (ret == 0);

                if (_connected)
                    Logger.Log($"[MX] 연결 성공: {_ipAddress}:{_port}");
                else
                    Logger.Log($"[MX] 연결 실패 ret={ret}");

                return _connected;
            }
            catch (Exception ex)
            {
                Logger.Log("[MX] 연결 오류: " + ex.Message);
                return false;
            }
        }

        public void Disconnect()
        {
            try { _plcType?.InvokeMember("Close", BindingFlags.InvokeMethod, null, _plc, null); }
            catch { }
            _connected = false;
        }

        // D영역 워드 읽기 후 PLCData1에 직접 저장
        public bool ReadWords(int startAddress, int count)
        {
            if (!_connected) return false;
            try
            {
                int[] buf = new int[count];
                object[] args = new object[] { $"D{startAddress}", count, buf };
                var pm = new ParameterModifier(3);
                pm[2] = true; // 3번째 파라미터 ref
                int ret = (int)_plcType.InvokeMember("ReadDeviceBlock",
                    BindingFlags.InvokeMethod, null, _plc, args,
                    new[] { pm }, null, null);

                if (ret != 0) return false;

                for (int i = 0; i < count; i++)
                {
                    int addr = startAddress + i;
                    if (addr >= 4000 && addr <= 4031)
                    {
                        int wi = addr - 4000;
                        for (int b = 0; b < 16; b++)
                            PLCData1.PlcValueBit[wi, b] = ((buf[i] >> b) & 1) == 1;
                    }
                    else
                    {
                        PLCData1.PlcValue[addr] = buf[i];
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("[MX] 읽기 오류: " + ex.Message);
                _connected = false;
                return false;
            }
        }

        public bool WriteWords(int startAddress, int count)
        {
            if (!_connected) return false;
            try
            {
                int[] data = new int[count];
                Array.Copy(PLCData1.writePlcValue, startAddress, data, 0, count);

                object[] args = new object[] { $"D{startAddress}", count, data };
                var pm = new ParameterModifier(3);
                pm[2] = true;
                int ret = (int)_plcType.InvokeMember("WriteDeviceBlock",
                    BindingFlags.InvokeMethod, null, _plc, args,
                    new[] { pm }, null, null);
                return ret == 0;
            }
            catch (Exception ex)
            {
                Logger.Log("[MX] 쓰기 오류: " + ex.Message);
                _connected = false;
                return false;
            }
        }

        public bool WriteBitWords(int startAddress, ushort[] data)
        {
            if (!_connected) return false;
            try
            {
                int[] intData = new int[data.Length];
                for (int i = 0; i < data.Length; i++)
                    intData[i] = data[i];

                object[] args = new object[] { $"D{startAddress}", intData.Length, intData };
                var pm = new ParameterModifier(3);
                pm[2] = true;
                int ret = (int)_plcType.InvokeMember("WriteDeviceBlock",
                    BindingFlags.InvokeMethod, null, _plc, args,
                    new[] { pm }, null, null);
                return ret == 0;
            }
            catch (Exception ex)
            {
                Logger.Log("[MX] 비트 쓰기 오류: " + ex.Message);
                _connected = false;
                return false;
            }
        }

        private void SetProp(string name, object value)
        {
            _plcType.InvokeMember(name, BindingFlags.SetProperty, null, _plc, new[] { value });
        }

        public void Dispose() => Disconnect();
    }
}
