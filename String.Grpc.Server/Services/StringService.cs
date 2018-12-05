using System.Threading.Tasks;
using Grpc.Core;

namespace String.Grpc.Server.Services
{
    public class StringService : String.StringBase
    {
        public override Task<LowerCaseResult> LowerCase(LowerCaseRequest request, ServerCallContext context)
        {
            if (string.IsNullOrWhiteSpace(request.String))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument,
                    $"Property {nameof(request.String)} is invalid"));
            }

            return Task.FromResult(new LowerCaseResult
            {
                String = request.String.ToLower()
            });
        }

        public override Task<UpperCaseResult> UpperCase(UpperCaseRequest request, ServerCallContext context)
        {
            if (string.IsNullOrWhiteSpace(request.String))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument,
                    $"Property {nameof(request.String)} is invalid"));
            }

            return Task.FromResult(new UpperCaseResult
            {
                String = request.String.ToUpper()
            });
        }
    }
}