using Grpc.Core;

namespace GrpcService.Services;

public class CityService : GrpcService.CityProtoService.CityProtoServiceBase
{
    public override Task<CityReply> SayCity(CityRequest request, ServerCallContext context)
    {
        return Task.FromResult(new CityReply
        {
            Message = $"My City {request.City}"
        });
    }
}