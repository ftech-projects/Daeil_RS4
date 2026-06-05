using System;
using System.IO;
using System.Net.Sockets;
using Sres.Net.EEIP;

namespace FbeiConfigProbe
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            var ip = args.Length > 0 ? args[0] : "192.168.250.11";
            if (args.Length > 1 && args[1].Equals("reset", StringComparison.OrdinalIgnoreCase))
            {
                return ResetIdentity(ip);
            }
            if (args.Length > 1 && args[1].Equals("get", StringComparison.OrdinalIgnoreCase))
            {
                if (args.Length < 5)
                {
                    Console.WriteLine("Usage: FbeiConfigProbe.exe <ip> get <class> <instance> <attribute>");
                    return 2;
                }
                return GetAttribute(ip, ParseInt(args[2]), ParseInt(args[3]), ParseInt(args[4]));
            }
            if (args.Length > 1 && args[1].Equals("set", StringComparison.OrdinalIgnoreCase))
            {
                if (args.Length < 6)
                {
                    Console.WriteLine("Usage: FbeiConfigProbe.exe <ip> set <class> <instance> <attribute> <hexData>");
                    return 2;
                }
                return SetAttribute(ip, ParseInt(args[2]), ParseInt(args[3]), ParseInt(args[4]), ParseHex(args[5]));
            }

            var instance = args.Length > 1 ? ParseInt(args[1]) : 0x66;
            var attr = args.Length > 2 ? ParseInt(args[2]) : 3;
            var writeData = args.Length > 3 ? ParseHex(args[3]) : null;

            try
            {
                var client = new EEIPClient();
                client.IPAddress = ip;
                client.RegisterSession();

                Console.WriteLine("Target: {0}", ip);
                Console.WriteLine("Identity Product Name: {0}", ToAscii(client.GetAttributeSingle(1, 1, 7)));
                Console.WriteLine("Identity Product Code: {0}", ToU16(client.GetAttributeSingle(1, 1, 3)));
                var rev = client.GetAttributeSingle(1, 1, 4);
                if (rev.Length >= 2)
                {
                    Console.WriteLine("Identity Revision: {0}.{1}", rev[0], rev[1]);
                }

                if (writeData != null)
                {
                    Console.WriteLine("Set Assembly Class 0x04 Instance 0x{0:X} Attribute {1}: {2}", instance, attr, ToHex(writeData));
                    client.SetAttributeSingle(4, instance, attr, writeData);
                }

                Console.WriteLine("Get Assembly Class 0x04 Instance 0x{0:X} Attribute {1}", instance, attr);
                var data = client.GetAttributeSingle(4, instance, attr);
                Console.WriteLine("Length: {0}", data.Length);
                Console.WriteLine("Data: {0}", ToHex(data));

                client.UnRegisterSession();
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: {0}", ex.Message);
                return 1;
            }
        }

        private static int GetAttribute(string ip, int classId, int instance, int attr)
        {
            try
            {
                var client = new EEIPClient();
                client.IPAddress = ip;
                client.RegisterSession();

                var data = client.GetAttributeSingle(classId, instance, attr);
                Console.WriteLine("Target: {0}", ip);
                Console.WriteLine("Get Class 0x{0:X} Instance 0x{1:X} Attribute {2}", classId, instance, attr);
                Console.WriteLine("Length: {0}", data.Length);
                Console.WriteLine("Data: {0}", ToHex(data));
                if (data.Length >= 2)
                {
                    Console.WriteLine("U16LE: 0x{0:X4} ({0})", ToU16(data));
                }
                if (data.Length >= 4)
                {
                    Console.WriteLine("U32LE: 0x{0:X8} ({0})", ToU32(data));
                }

                client.UnRegisterSession();
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: {0}", ex.Message);
                return 1;
            }
        }

        private static int SetAttribute(string ip, int classId, int instance, int attr, byte[] writeData)
        {
            try
            {
                var client = new EEIPClient();
                client.IPAddress = ip;
                client.RegisterSession();

                Console.WriteLine("Target: {0}", ip);
                Console.WriteLine("Set Class 0x{0:X} Instance 0x{1:X} Attribute {2}: {3}", classId, instance, attr, ToHex(writeData));
                client.SetAttributeSingle(classId, instance, attr, writeData);
                var data = client.GetAttributeSingle(classId, instance, attr);
                Console.WriteLine("Readback Length: {0}", data.Length);
                Console.WriteLine("Readback Data: {0}", ToHex(data));

                client.UnRegisterSession();
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: {0}", ex.Message);
                return 1;
            }
        }

        private static int ResetIdentity(string ip)
        {
            try
            {
                using (var tcp = new TcpClient())
                {
                    tcp.Connect(ip, 44818);
                    var stream = tcp.GetStream();
                    stream.Write(BuildRegisterSession(), 0, 28);
                    var registerResponse = ReadSome(stream);
                    var session = BitConverter.ToUInt32(registerResponse, 4);
                    Console.WriteLine("Target: {0}", ip);
                    Console.WriteLine("Session: 0x{0:X8}", session);

                    var reset = BuildIdentityReset(session);
                    stream.Write(reset, 0, reset.Length);
                    var response = ReadSome(stream);
                    Console.WriteLine("Reset response: {0}", ToHex(response));
                    if (response.Length > 42)
                    {
                        Console.WriteLine("CIP General Status: 0x{0:X2}", response[42]);
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: {0}", ex.Message);
                return 1;
            }
        }

        private static byte[] BuildRegisterSession()
        {
            return new byte[]
            {
                0x65, 0x00, 0x04, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x01, 0x00, 0x00, 0x00
            };
        }

        private static byte[] BuildIdentityReset(uint session)
        {
            var cip = new byte[] { 0x05, 0x02, 0x20, 0x01, 0x24, 0x01, 0x00 };
            var cpfLength = 4 + 2 + 2 + 4 + 4 + cip.Length;
            var packet = new byte[24 + cpfLength];

            WriteU16(packet, 0, 0x006F);
            WriteU16(packet, 2, (ushort)cpfLength);
            WriteU32(packet, 4, session);

            var offset = 24;
            offset += 4; // interface handle
            offset += 2; // timeout
            WriteU16(packet, offset, 2); offset += 2;
            WriteU16(packet, offset, 0x0000); offset += 2;
            WriteU16(packet, offset, 0x0000); offset += 2;
            WriteU16(packet, offset, 0x00B2); offset += 2;
            WriteU16(packet, offset, (ushort)cip.Length); offset += 2;
            Buffer.BlockCopy(cip, 0, packet, offset, cip.Length);

            return packet;
        }

        private static byte[] ReadSome(Stream stream)
        {
            var buffer = new byte[564];
            var read = stream.Read(buffer, 0, buffer.Length);
            var data = new byte[read];
            Buffer.BlockCopy(buffer, 0, data, 0, read);
            return data;
        }

        private static void WriteU16(byte[] data, int offset, ushort value)
        {
            data[offset] = (byte)value;
            data[offset + 1] = (byte)(value >> 8);
        }

        private static void WriteU32(byte[] data, int offset, uint value)
        {
            data[offset] = (byte)value;
            data[offset + 1] = (byte)(value >> 8);
            data[offset + 2] = (byte)(value >> 16);
            data[offset + 3] = (byte)(value >> 24);
        }

        private static ushort ToU16(byte[] data)
        {
            return data.Length >= 2 ? (ushort)(data[0] | (data[1] << 8)) : (ushort)0;
        }

        private static uint ToU32(byte[] data)
        {
            if (data.Length < 4)
            {
                return 0;
            }
            return (uint)(data[0] | (data[1] << 8) | (data[2] << 16) | (data[3] << 24));
        }

        private static int ParseInt(string value)
        {
            if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                return Convert.ToInt32(value.Substring(2), 16);
            }
            return Convert.ToInt32(value, 10);
        }

        private static string ToAscii(byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                return string.Empty;
            }
            var len = (int)data[0];
            if (len > data.Length - 1)
            {
                len = data.Length - 1;
            }
            return System.Text.Encoding.ASCII.GetString(data, 1, len);
        }

        private static string ToHex(byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                return "(empty)";
            }
            return BitConverter.ToString(data).Replace("-", " ");
        }

        private static byte[] ParseHex(string value)
        {
            value = value.Replace(" ", string.Empty).Replace("-", string.Empty);
            if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                value = value.Substring(2);
            }
            if ((value.Length % 2) != 0)
            {
                throw new ArgumentException("Hex string must have an even number of digits.");
            }

            var data = new byte[value.Length / 2];
            for (var i = 0; i < data.Length; i++)
            {
                data[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
            }
            return data;
        }
    }
}
