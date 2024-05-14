using System.Net;
using System.Net.Sockets;
using System.Text;

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");

// Uncomment this block to pass the first stage
TcpListener server = new TcpListener(IPAddress.Any, 6379);
server.Start();
var socket = await server.AcceptSocketAsync(); // wait for client1

while(true)
{
    using var stream = new NetworkStream(socket);
    var buffer = new byte[1024];
    var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
    var request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
    Console.WriteLine(request);
    var response = Encoding.UTF8.GetBytes("+PONG\r\n");
    await stream.WriteAsync(response, 0, response.Length);
}


