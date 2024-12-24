using System;
using System.Collections.Generic;
using System.Threading;

public class QualityCheck
{
    public delegate void QualityCheckDelegate(IVehicle car, string carId);
    public event QualityCheckDelegate? QualityCheckEvent;

    private Dictionary<string, List<string>> qualityCheckResults = new Dictionary<string, List<string>>(); // Car ID -> qc Results

    public void CheckQuality(IVehicle car, string carId)
    {
        Console.WriteLine($"\nPerforming quality check for Car ID: {carId}, Car: {car.Brand} {car.Model}");
        Thread.Sleep(1000);

        Console.WriteLine("Checking engine...");
        Thread.Sleep(500);
        AddQualityResult(carId, "Engine: Passed");

        Console.WriteLine("Checking body...");
        Thread.Sleep(500);
        AddQualityResult(carId, "Body: Passed");

        Console.WriteLine("Checking safety features...");
        Thread.Sleep(500);
        AddQualityResult(carId, "Safety Features: Passed");
        Thread.Sleep(1000);
        //Console.WriteLine();
        Console.WriteLine();

        Logger.Log($"Car ID: {carId}, {car.Brand} {car.Model}: Quality check completed.");
        QualityCheckEvent?.Invoke(car, carId); // invoke subscriber event
    }

    private void AddQualityResult(string carId, string result)
    {
        if (!qualityCheckResults.ContainsKey(carId))
        {
            qualityCheckResults[carId] = new List<string>();
        }
        qualityCheckResults[carId].Add(result);
    }

    public List<string> GetQualityResults(string carId)
    {
        return qualityCheckResults.ContainsKey(carId) ? qualityCheckResults[carId] : new List<string> { "No quality check results found." };
    }
}