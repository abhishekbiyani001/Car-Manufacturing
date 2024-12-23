using System;
using System.Threading;

public class OrderProcessing
{
    public delegate void OrderProcessingDelegate(IVehicle car);
    public event OrderProcessingDelegate? OrderProcessedEvent;

    public void ProcessOrder(IVehicle car)
    {
        Thread.Sleep(1500);
        Console.WriteLine("\nProcessing order...");
        OrderProcessedEvent?.Invoke(car);
        Thread.Sleep(2000);
        Logger.Log($"{car.Brand} {car.Model}: Order processed.");
        Console.WriteLine("Order processing completed.");
        Console.WriteLine();
        Thread.Sleep(1000);
    }
}