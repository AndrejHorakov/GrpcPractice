using Grpc.Core;
using Grpc.Net.Client;
using GrpcPractice2;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7093");
var client = new Weather.WeatherClient(channel);
var call = client.GetWeatherStream(new WeatherRequest());
await foreach (var response in call.ResponseStream.ReadAllAsync())
{
    var time = DateTime.Parse(response.DateTime);
    Console.WriteLine($"{response.Now} погода на {time:dd.MM.yyyy HH:mm} = {response.Temperature}C");
}
Console.WriteLine("Press any key to exit...");
Console.ReadKey();