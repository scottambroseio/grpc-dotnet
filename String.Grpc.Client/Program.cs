using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace String.Grpc.Client
{
    public class Program
    {
        public static async Task Main()
        {
            var channel = new Channel("localhost", 50001, ChannelCredentials.Insecure);
            var client = new String.StringClient(channel);

            var lowerCaseResult = await client.LowerCaseAsync(new LowerCaseRequest()
            {
                String = "HELLO"
            });

            Console.WriteLine($"Method: {nameof(client.LowerCaseAsync)}");
            Console.WriteLine($"Input: HELLO");
            Console.WriteLine($"Output: {lowerCaseResult.String}");
            Console.WriteLine();

            var upperCaseResult = await client.UpperCaseAsync(new UpperCaseRequest()
            {
                String = "hello"
            });

            Console.WriteLine($"Method: {nameof(client.UpperCaseAsync)}");
            Console.WriteLine($"Input: hello");
            Console.WriteLine($"Output: {upperCaseResult.String}");
            Console.WriteLine();

            try
            {
                await client.UpperCaseAsync(new UpperCaseRequest());
            }
            catch (RpcException ex)
            {
                Console.WriteLine($"Method: {nameof(client.UpperCaseAsync)}");
                Console.WriteLine($"Input: null");
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine();
            }

            await channel.ShutdownAsync();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}