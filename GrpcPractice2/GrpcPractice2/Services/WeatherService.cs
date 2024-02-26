using Grpc.Core;
using GrpcPractice2.StaticData;

namespace GrpcPractice2.Services;

public class WeatherService : Weather.WeatherBase
{
    public override async Task GetWeatherStream(
        WeatherRequest request,
        IServerStreamWriter<WeatherData> responseStream,
        ServerCallContext context)
    {
        var openMeteoResponse = await WeatherAPIData.GetOpenMeteoResponse();

        int i = 0;
        while (!context.CancellationToken.IsCancellationRequested && i < openMeteoResponse.Hourly.Time.Length)
        {
            // Добавление полученных данных в responseStream
            await responseStream.WriteAsync(new WeatherData
            {
                Now = DateTime.Now.ToString("HH.mm.ss"),
                DateTime = openMeteoResponse.Hourly.Time[i],
                Temperature = openMeteoResponse.Hourly.Temperature_2m[i]
            });
            // Задержка на секунду
            i += 2;
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}