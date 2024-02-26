using Grpc.Core;
using Grpc.Net.Client;
using GrpcPractice2;

using var channel = GrpcChannel.ForAddress("https://localhost:7093");
var client = new JwtGenerator.JwtGeneratorClient(channel);
var call = client.GetJWToken(new TokenRequest());
var jwtToken = call.Token;

var clientGr = new Greeter.GreeterClient(channel);
var headers = new Metadata();
headers.Add("Authorization", "Bearer " + jwtToken);
var callGr = clientGr.SayHelloAsync(new HelloRequest(), headers: headers);
Console.WriteLine(callGr.ResponseAsync.Result.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();