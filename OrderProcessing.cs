using System;
using System.Collections.Generic;
using System.Threading;

public class OrderProcessing
{
    public delegate void OrderProcessingDelegate(IVehicle car, string orderId);
    public event OrderProcessingDelegate? OrderProcessedEvent;

    private Dictionary<string, string> orderStatuses = new Dictionary<string, string>(); // Order ID -> Status

    public void ProcessOrder(IVehicle car, string orderId)
    {
        Console.WriteLine($"\nStarting order processing for Order ID: {orderId}, Car: {car.Brand} {car.Model}");
        Thread.Sleep(1000);

        Console.WriteLine("Validating order...");
        Thread.Sleep(500);
        orderStatuses[orderId] = "Validated";
        Console.WriteLine("Order validated.");

        Console.WriteLine("Processing order...");
        Thread.Sleep(1000);
        orderStatuses[orderId] = "Processing";

        OrderProcessedEvent?.Invoke(car, orderId);

        Thread.Sleep(2000);
        orderStatuses[orderId] = "Completed";
        Logger.Log($"Order ID: {orderId}, {car.Brand} {car.Model}: Order processed.");
        Console.WriteLine("Order processing completed.");
    }

    public string GetOrderStatus(string orderId)
    {
        return orderStatuses.ContainsKey(orderId) ? orderStatuses[orderId] : "Order not found.";
    }
}