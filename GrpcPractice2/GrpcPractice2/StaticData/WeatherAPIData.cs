using GrpcPractice2.Models;
using Newtonsoft.Json;

namespace GrpcPractice2.StaticData;

public static class WeatherAPIData
{
    private static OpenMeteoResponse? _response = null;

    public static async  Task<OpenMeteoResponse> GetOpenMeteoResponse()
    {
        HttpClient client = new HttpClient();
        if (_response is null)
        {
            var response = await client.GetAsync(
                "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m");
            var data = await response.Content.ReadAsStringAsync();
            
            _response = JsonConvert.DeserializeObject<OpenMeteoResponse>(data);
        }
        
        return _response!;
    }
}