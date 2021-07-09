using System;
using System.Net;
using System.Net.Sockets;
using Microsoft.Extensions.Logging;
using ZigBeeNet.Transport;
using ZigBeeNet.Util;

namespace ZigBeeNet.Tranport.Net
{
    public class ZigBeeTcpPort : IZigBeePort, IDisposable
    {
        private static ILogger _logger = LogManager.GetLog<ZigBeeTcpPort>();

        private Socket _socket;

        public IPEndPoint EndPoint { get; private set; }


        public bool IsOpen { get => _socket != null && _socket.Connected; }

        public ZigBeeTcpPort(IPEndPoint endPoint)
        {
            EndPoint = endPoint;
        }

        public void Close()
        {
            if (_socket != null)
            {
                _socket.Close();
                _socket.Dispose();
                _socket = null;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _socket?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool Open()
        {
            return Open(0);
        }

        public bool Open(int baudrate)
        {
            return Open(baudrate, FlowControl.FLOWCONTROL_OUT_NONE);
        }

        public bool Open(int baudrate, FlowControl flowControl)
        {
            _logger.LogDebug("Opening TCP connection to {EndPoint}", EndPoint);

            try
            {
                _socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                _socket.Connect(EndPoint);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error connecting to {EndPoint}", EndPoint);
                _socket?.Dispose();
                _socket = null;
                return false;
            }

            return true;
        }

        public void PurgeRxBuffer()
        {
            int available = _socket.Available;
            if (available > 0)
            {
                var buffer = new byte[available];
                _socket.Receive(buffer);
            }
        }

        public byte? Read()
        {
            return Read(-1);
        }

        public byte? Read(int timeout)
        {
            try
            {
                _socket.ReceiveTimeout = timeout;
                byte[] buffer = new byte[1];
                int received = _socket.Receive(buffer);
                return received > 0 ? buffer[0] : (byte?)null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error receiving byte");
                return null;
            }
        }

        public void Write(byte[] value)
        {
            if (_socket == null)
            {
                return;
            }

            int totalSent = 0;
            while (totalSent < value.Length)
            {
                try
                {
                    int sent = _socket.Send(value, totalSent, value.Length - totalSent, SocketFlags.None);
                    totalSent += sent;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending data");
                }
            }
        }
    }
}
