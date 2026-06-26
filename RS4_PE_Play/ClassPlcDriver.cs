using System;
using System.Reflection;
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


    // 미쓰비시 MX Component 이더넷 — 동적 COM 바인딩, 1워드씩 읽기/쓰기
    public class MelsecMxDriver : IPlcDriver
    {
        private readonly string _ipAddress;
        private object _plc;
        private Type _plcType;
        private bool _connected;

        public bool IsConnected => _connected;

        private const int CPU_TYPE_Q04UDEH = 210;

        public MelsecMxDriver(string ipAddress, int port = 5001, System.Windows.Forms.Form hostForm = null)
        {
            _ipAddress = ipAddress;
        }

        public bool Connect()
        {
            try
            {
                string[] progIds = {
                    "ActEther.ActQNUDECPUTCP",
                    "ActEther.ActQNUDECPUTCP.1",
                    "ACTEtherLib.ActQNUDECPUTCP",
                    "ACT.ActQNUDECPUTCP"
                };
                foreach (var id in progIds)
                {
                    _plcType = Type.GetTypeFromProgID(id);
                    if (_plcType != null) break;
                }
                if (_plcType == null) { Logger.Log("[MX] MX Component 미설치"); return false; }

                _plc = Activator.CreateInstance(_plcType);
                SetProp("ActCpuType",    CPU_TYPE_Q04UDEH);
                SetProp("ActHostAddress", _ipAddress);

                int ret = (int)_plcType.InvokeMember("Open", BindingFlags.InvokeMethod, null, _plc, null);
                _connected = (ret == 0);
                Logger.Log(_connected ? $"[MX] 연결 성공: {_ipAddress}" : $"[MX] 연결 실패 ret={ret:X}");
                return _connected;
            }
            catch (Exception ex) { Logger.Log("[MX] 연결 오류: " + ex.Message); return false; }
        }

        public void Disconnect()
        {
            try { _plcType?.InvokeMember("Close", BindingFlags.InvokeMethod, null, _plc, null); }
            catch { }
            _connected = false;
        }

        // D워드 1개씩 읽기 — ReadDeviceBlock(szDevice, 1, ref int)
        public bool ReadWords(int startAddress, int count)
        {
            if (!_connected) return false;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    object[] args = { $"D{startAddress + i}", 1, (object)0 };
                    var pm = new ParameterModifier(3);
                    pm[2] = true;
                    int ret = (int)_plcType.InvokeMember("ReadDeviceBlock",
                        BindingFlags.InvokeMethod, null, _plc, args, new[] { pm }, null, null);
                    if (ret != 0) continue;

                    int wordVal = Convert.ToInt32(args[2]);
                    int addr = startAddress + i;
                    if (addr >= 4000 && addr <= 4031)
                    {
                        int wi = addr - 4000;
                        for (int b = 0; b < 16; b++)
                            PLCData1.PlcValueBit[wi, b] = ((wordVal >> b) & 1) == 1;
                    }
                    else
                    {
                        PLCData1.PlcValue[addr] = wordVal;
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
                for (int i = 0; i < count; i++)
                {
                    int v = PLCData1.writePlcValue[startAddress + i];
                    if (PLCData1.lastWriteBuffer[startAddress + i] == v) continue; // 변경 없으면 스킵
                    object[] args = { $"D{startAddress + i}", 1, (object)v };
                    Logger.Log($"[MX] Write D{startAddress + i} = {v}");
                    int ret = (int)_plcType.InvokeMember("WriteDeviceBlock",
                        BindingFlags.InvokeMethod, null, _plc, args, null, null, null);
                    Logger.Log($"[MX] Write D{startAddress + i} ret=0x{ret:X}");
                    if (ret == 0) PLCData1.lastWriteBuffer[startAddress + i] = v;
                    else Logger.Log($"[MX] D{startAddress + i} 쓰기 실패 ret=0x{ret:X}");
                }
                return true;
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
                for (int i = 0; i < data.Length; i++)
                {
                    int v = (int)data[i];
                    if (PLCData1.lastWriteBuffer[startAddress + i] == v) continue;
                    object[] args = { $"D{startAddress + i}", 1, (object)v };
                    int ret = (int)_plcType.InvokeMember("WriteDeviceBlock",
                        BindingFlags.InvokeMethod, null, _plc, args, null, null, null);
                    if (ret == 0) PLCData1.lastWriteBuffer[startAddress + i] = v;
                    else Logger.Log($"[MX] D{startAddress + i} 비트 쓰기 실패 ret=0x{ret:X}");
                }
                return true;
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
