using System;

public class Program
{
    public static void Main(string[] args)
    {
        string? BrandName;
        string? ModelName;

        while (true)
        {
            Console.WriteLine("Enter brand name (BMW, Audi, Mercedes, Lamborghini, Porsche) or 'exit' to quit: ");
            BrandName = Console.ReadLine()!;
            if (BrandName.ToLower() == "exit")
                break;

            Console.WriteLine("Enter model name: ");
            ModelName = Console.ReadLine()!;

            IVehicle? car = BrandName.ToLower() switch
            {
                "bmw" => new BMW { Brand = "BMW", Model = ModelName },
                "audi" => new Audi { Brand = "Audi", Model = ModelName },
                "mercedes" => new Mercedes { Brand = "Mercedes", Model = ModelName },
                "lamborghini" => new Lamborghini { Brand = "Lamborghini", Model = ModelName },
                "porsche" => new Porsche { Brand = "Porsche", Model = ModelName },
                _ => null
            };

            if (car != null)
            {
                ExecuteCarOperations(car);
            }
            else
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

        // Subscribe to events
        qc.QualityCheckEvent += qcHandler;
        op.OrderProcessedEvent += opHandler;

        void qcHandler(IVehicle c)
        {
            Console.WriteLine($"Quality check completed for {c.Brand} {c.Model}. Triggering order processing...");
            op.ProcessOrder(c);
        }

        void opHandler(IVehicle c)
        {
            Console.WriteLine($"Order processed for {c.Brand} {c.Model}. Thank you for your purchase!");
        }

        qc.CheckQuality(car);

        // Unsubscribe from events
        qc.QualityCheckEvent -= qcHandler;
        op.OrderProcessedEvent -= opHandler;
    }
}