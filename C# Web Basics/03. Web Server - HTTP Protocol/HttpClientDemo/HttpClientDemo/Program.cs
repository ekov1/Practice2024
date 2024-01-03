using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HttpClientDemo
{
    internal class Program
    {
        static async Task Main()
        {
            const string NewLine = "\r\n";
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80); // localhost
            //TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345); // localhost:12345
            // await ReadData();
            tcpListener.Start();

            // daemon // service
            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using (var stream = client.GetStream())
                {
                    int byteLength = 0;
                    byte[] buffer = new byte[1000000];
                    var length = stream.Read(buffer, byteLength, buffer.Length);

                    string requestString = Encoding.UTF8.GetString(buffer, 0, length);
                    Console.WriteLine(requestString);

                    string html = $"<h1>Hello from SamuraiServer {DateTime.Now}</h1>" +
                        "<form method=post>" +
                        "<input name=username /><input name=password />" +
                        "<input type=submit />" +
                        "</form>";

                    string response = "HTTP/1.1 200 OK" + NewLine +
                        "Server: Samurai 2024" + NewLine +
                        "Content-Type: text/html; charset=utf-8" + NewLine +
                        "Content-Length: " + html.Length + NewLine +
                        NewLine +
                        html +
                        NewLine;

                    string responseTextPlain = "HTTP/1.1 200 OK" + NewLine +
                        "Server: Samurai 2024" + NewLine +
                        "Content-Type: text/plain; charset=utf-8" + NewLine +
                        "Content-Length: " + html.Length + NewLine +
                        NewLine +
                        html +
                        NewLine;

                    string responseContentDisposition = "HTTP/1.1 200 OK" + NewLine +
                       "Server: Samurai 2024" + NewLine +
                       "Content-Type: text/plain; charset=utf-8" + NewLine +
                       "Content-Disposition: attachment; filename=samurai.txt" + NewLine +
                       "Content-Length: " + html.Length + NewLine +
                       NewLine +
                       html +
                       NewLine;

                    string redirectResponse = "HTTP/1.1 307 Redirect" + NewLine +
                        "Server: Samurai 2024" + NewLine +
                        "Location: https://dir.bg" + NewLine +
                        "Content-Type: text/html; charset=utf-8" + NewLine +
                        "Content-Length: " + html.Length + NewLine +
                        NewLine +
                        html + NewLine;

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);

                    Console.WriteLine(new string('=', 77));
                }
            }
        }

        static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string url = "https://dir.bg/";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            //Console.WriteLine(response);

            Console.WriteLine("serverInfo.StatusCode: " + response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine, response.Headers.Select(x => x.Key + ":" + x.Value)));

            //var html = await client.GetStringAsync(url);
            //Console.WriteLine(html);
        }
    }
}