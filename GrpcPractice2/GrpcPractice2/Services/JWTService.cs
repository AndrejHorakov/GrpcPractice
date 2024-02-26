using Grpc.Core;

namespace GrpcPractice2.Services;

public class JWTService : JwtGenerator.JwtGeneratorBase
{
    public override Task GetJWToken(TokenRequest request, IServerStreamWriter<TokenData> responseStream, ServerCallContext context)
    {
        
    }
}