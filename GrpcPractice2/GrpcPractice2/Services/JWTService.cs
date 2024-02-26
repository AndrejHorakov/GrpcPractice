using Grpc.Core;
using GrpcPractice2.JwtAuthGenerator;

namespace GrpcPractice2.Services;

public class JwtService : JwtGenerator.JwtGeneratorBase
{
    private readonly IJwtAuthService _jWtAuthenticationManager;

    public JwtService(IJwtAuthService jWtAuthenticationManager)
    {
        _jWtAuthenticationManager = jWtAuthenticationManager;
    }

    public override Task<TokenData> GetJWToken(TokenRequest request, ServerCallContext context)
    {
        var token = _jWtAuthenticationManager.Authenticate("test1", "password1");

        return Task.FromResult(new TokenData
        {
            Token = token
        });
    }
}