using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using String.Grpc.Server.Services;

namespace String.Grpc.Server
{
    public class Program
    {
        public static async Task Main()
        {
            var host = new HostBuilder()
                .ConfigureLogging(logging => logging.AddConsole())
                .ConfigureServices(services =>
                {
                    var server = new global::Grpc.Core.Server
                    {
                        Services = {String.BindService(new StringService())},
                        Ports = {new ServerPort("localhost", 50001, ServerCredentials.Insecure)}
                    };

                    services.AddSingleton(server);
                    services.AddHostedService<HostedGrpcService>();
                });

            await host.RunConsoleAsync();
        }
    }
}