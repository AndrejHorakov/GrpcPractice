namespace GrpcPractice2.Models;

public class OpenMeteoResponse
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public HourlyReport Hourly { get; set; } = default!;
}