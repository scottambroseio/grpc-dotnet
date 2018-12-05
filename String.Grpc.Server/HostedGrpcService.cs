using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace String.Grpc.Server
{
    public class HostedGrpcService : IHostedService
    {
        private readonly ILogger<HostedGrpcService> logger;
        private readonly global::Grpc.Core.Server server;

        public HostedGrpcService(global::Grpc.Core.Server server, ILogger<HostedGrpcService> logger)
        {
            this.server = server;
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting GRPC Server");

            server.Start();

            logger.LogInformation("GRPC Server Started");

            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Terminating GRPC Server");

            await server.ShutdownAsync();

            logger.LogInformation("GRPC Server Terminated");
        }
    }
}