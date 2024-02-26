namespace GrpcPractice2.Models;

public class HourlyReport
{
    public string[] Time { get; set; } = default!;
    public double[] Temperature_2m { get; set; } = default!;
}