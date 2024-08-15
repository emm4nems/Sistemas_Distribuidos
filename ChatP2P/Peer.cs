using System.Net;
using System.Net.Sockets;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChatP2P
{
    public class Peer
    {
        private readonly TcpListener _listener;
        private TcpClient? _client;
        private readonly int _port;

        public Peer(int port)
        {
            _port = port;
            _listener = new TcpListener(IPAddress.Any, _port);
        }

        public async Task ConnectToPeer(string ipAddress, string port)
        {
            try
            {
                _client = new TcpClient(ipAddress, Convert.ToInt32(port));
                Console.WriteLine("Connected to peer :D");

                var receiveTask = ReceiveMessages();
                await SendMessages();
                await receiveTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection closed :c " + ex.Message);
            }
        }

        public async Task StartListening()
        {
            try
            {
                _listener.Start();
                Console.WriteLine("Listening for incoming connections on port " + _port);
                _client = await _listener.AcceptTcpClientAsync();
                Console.WriteLine("Connected to peer...");

                var receiveTask = ReceiveMessages();
                await SendMessages();
                await receiveTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection closed :c " + ex.Message);
            }
        }

        private async Task ReceiveMessages()
        {
            try
            {
                var stream = _client!.GetStream();
                var reader = new StreamReader(stream, Encoding.UTF8);

                while (_client.Connected)
                {
                    var message = await reader.ReadLineAsync();
                    if (message != null)
                    {
                        Console.WriteLine($"Received message: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving message: {ex.Message}");
            }
            finally
            {
                Close();
            }
        }

        private async Task SendMessages()
        {
            try
            {
                var stream = _client!.GetStream();
                var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

                while (_client.Connected)
                {
                    var message = Console.ReadLine();
                    if (message != null)
                    {
                        await writer.WriteLineAsync(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
            }
            finally
            {
                Close();
            }
        }

        private void Close()
        {
            _client?.Close();
            _listener.Stop();
        }
    }
}
