using System;
using System.Threading;

public class QualityCheck
{
    public delegate void QualityCheckDelegate(IVehicle car);
    public event QualityCheckDelegate? QualityCheckEvent;

    public void CheckQuality(IVehicle car)
    {
        Thread.Sleep(1000);
        Console.WriteLine("\nPerforming quality check...");
        Logger.Log($"{car.Brand} {car.Model}: Quality check completed.");
        QualityCheckEvent?.Invoke(car);
    }
}