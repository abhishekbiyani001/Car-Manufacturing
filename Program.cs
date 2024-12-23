using System;
using System.Threading;

public interface IVehicle
{
    string Brand {
        get;
        set;
    }
    string Model {
        get;
        set;
    }

    void StartEngine();
    void Accelerate();
    void Brake();
    void StopEngine();
}

public class Volkswagen : IVehicle
{
    public required string Brand {
        get;
        set;
    }
    public required string Model {
        get;
        set;
    }

    public virtual void StartEngine()
    {
        Console.WriteLine();
        Console.WriteLine($"{Brand} engine started...");
        Thread.Sleep(750);
    }

    public virtual void Accelerate()
    {
        Console.WriteLine($"{Brand} accelerating...");
        Thread.Sleep(750);
    }

    public virtual void Brake()
    {
        Console.WriteLine($"{Brand} braking...");
        Thread.Sleep(750);
    }

    public virtual void StopEngine()
    {
        Console.WriteLine($"{Brand} engine stopped...");
        Thread.Sleep(750);
    }
}

public class BMW : Volkswagen { }
public class Audi : Volkswagen { }
public class Mercedes : Volkswagen { }
public class Lamborghini : Volkswagen { }
public class Porsche : Volkswagen { }

public class QualityCheck
{
    public delegate void QualityCheckDelegate(IVehicle car);
    public event QualityCheckDelegate? QualityCheckEvent;

    public void CheckQuality(IVehicle car)
    {
        Thread.Sleep(750);
        Console.WriteLine("\nPerforming quality check...");
        QualityCheckEvent?.Invoke(car);
    }
}

public class OrderProcessing
{
    public delegate void OrderProcessingDelegate(IVehicle car);
    public event OrderProcessingDelegate? OrderProcessedEvent;

    public void ProcessOrder(IVehicle car)
    {
        Thread.Sleep(750);
        Console.WriteLine("\nProcessing order...");
        OrderProcessedEvent?.Invoke(car);
        Thread.Sleep(2000);
        Console.WriteLine("Order processing completed.");
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string? BrandName;
        string? ModelName;

        while (true)
        {
            Console.WriteLine("Enter brand name (BMW, Audi, Mercedes, Lamborghini, Porsche): ");
            BrandName = Console.ReadLine()!;
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

        // Subscribe to events
        qc.QualityCheckEvent += c =>
        {
            Console.WriteLine($"Quality check completed for {c.Brand} {c.Model}. Triggering order processing...");
            op.ProcessOrder(c);
        };
        op.OrderProcessedEvent += c =>
        {
            Console.WriteLine($"Order processed for {c.Brand} {c.Model}. Thank you for your purchase!");
        };
        qc.CheckQuality(car);

        // Unsubcsribe from events
        qc.QualityCheckEvent -= c =>
        {
            Console.WriteLine($"Quality check completed for {c.Brand} {c.Model}. Triggering order processing...");
            op.ProcessOrder(c);
        };
        op.OrderProcessedEvent -= c =>
        {
            Console.WriteLine($"Order processed for {c.Brand} {c.Model}. Thank you for your purchase!");
        };
    }
}