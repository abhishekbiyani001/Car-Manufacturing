using System;

public class Program
{
    public static void Main(string[] args)
    {
        string? BrandName;
        string? ModelName;

        while (true)
        {
            Console.WriteLine("Enter brand name (Bentley, Audi, Skoda, Lamborghini, Porsche) or 'exit' to quit: ");
            BrandName = Console.ReadLine()!;
            if (BrandName.ToLower() == "exit")
                break;

            Console.WriteLine("Enter model name: ");
            ModelName = Console.ReadLine()!;

            IVehicle? car = BrandName.ToLower() switch
            {
                "bentley" => new Bentley { Brand = "Bentley", Model = ModelName },
                "audi" => new Audi { Brand = "Audi", Model = ModelName },
                "skoda" => new Skoda { Brand = "Skoda", Model = ModelName },
                "lamborghini" => new Lamborghini { Brand = "Lamborghini", Model = ModelName },
                "porsche" => new Porsche { Brand = "Porsche", Model = ModelName },
                _ => null
            };

            if (car != null)
            {
                ExecuteCarOperations(car);
            }
            else if (car == null)
            {
                Console.WriteLine("Invalid brand name. Please enter a valid brand.");
            }
        }
    }

    private static void ExecuteCarOperations(IVehicle car)
    {
        car.StartEngine();
        car.Accelerate();
        car.Brake();
        car.StopEngine();

        QualityCheck qc = new QualityCheck();
        OrderProcessing op = new OrderProcessing();

        // generate unique IDs for car and order
        string carId = GenerateShortId();
        string orderId = GenerateShortId();

        static string GenerateShortId()
        {
            Random random = new Random();
            return random.Next(10000, 100000).ToString();
        }

        // Subscribe to events (lambda expressions)
        qc.QualityCheckEvent += (IVehicle c, string cId) =>
        {
            Console.WriteLine($"Event Triggered: Quality check completed for {c.Brand} {c.Model} (Car ID: {cId}). Triggering order processing...");
            op.ProcessOrder(c, orderId); // trigger order processing
        };

        op.OrderProcessedEvent += (IVehicle c, string oId) =>
        {
            Console.WriteLine($"Event Triggered: Order processing for {c.Brand} {c.Model} (Order ID: {oId}). Thank you for your purchase!");
            Console.WriteLine($"Order Status: {op.GetOrderStatus(oId)}");
        };

        qc.CheckQuality(car, carId);

        Console.WriteLine();
        Console.WriteLine("Quality Check Results:");
        foreach (var result in qc.GetQualityResults(carId))
        {
            Console.WriteLine($"- {result}");
        }
        Console.WriteLine();
        Thread.Sleep(1000);

        // Unsubscribe from events
        qc.QualityCheckEvent -= (IVehicle c, string cId) =>
        {
            Console.WriteLine($"Event Triggered: Quality check completed for {c.Brand} {c.Model} (Car ID: {cId}). Triggering order processing...");
            op.ProcessOrder(c, orderId);
        };

        op.OrderProcessedEvent -= (IVehicle c, string oId) =>
        {
            Console.WriteLine($"Event Triggered: Order processed for {c.Brand} {c.Model} (Order ID: {oId}). Thank you for your purchase!");
            Console.WriteLine();
            Console.WriteLine($"Order Status: {op.GetOrderStatus(oId)}");
        };
    }
}