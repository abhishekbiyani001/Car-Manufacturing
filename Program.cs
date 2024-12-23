using System;
using System.Threading;

public class Volkswagen
{
    required public string Brand {
        get;
        set;
    }
    required public string Model {
        get;
        set;
    }

    public virtual void StartEngine()
    {
        Console.WriteLine();
        Console.WriteLine($"{Brand} engine started...");
        Thread.Sleep(750);
    }
    public virtual void StopEngine()
    {
        Console.WriteLine($"{Brand} engine stopped...");
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
}

public class BMW : Volkswagen { }
public class Audi : Volkswagen { }
public class Mercedes : Volkswagen { }

public class QualityCheck
{
    public delegate void QualityCheckDelegate(Volkswagen car);
    public event QualityCheckDelegate? QualityCheckEvent;

    public void CheckQuality(Volkswagen car)
    {
        Thread.Sleep(750);
        Console.WriteLine("\nPerforming quality check...");
        QualityCheckEvent?.Invoke(car);
        //Console.WriteLine("Quality check completed.");
    }
}

public class OrderProcessing
{
    public delegate void OrderProcessingDelegate(Volkswagen car);
    public event OrderProcessingDelegate? OrderProcessedEvent;

    public void ProcessOrder(Volkswagen car)
    {
        Thread.Sleep(750);
        Console.WriteLine("\nProcessing order...");
        OrderProcessedEvent?.Invoke(car);
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
            Console.WriteLine("Enter brand name (BMW, Audi, Mercedes): ");
            BrandName = Console.ReadLine()!;
            Console.WriteLine("Enter model name: ");
            ModelName = Console.ReadLine()!;

            Volkswagen? car = BrandName switch
            {
                "BMW" => new BMW { Brand = BrandName, Model = ModelName },
                "Audi" => new Audi { Brand = BrandName, Model = ModelName },
                "Mercedes" => new Mercedes { Brand = BrandName, Model = ModelName },
                _ => null
            };

            if (car != null)
            {
                ExecuteCarOperations(car);
            }
            else
            {
                Console.WriteLine("Invalid brand name. Please enter BMW, Audi, or Mercedes.");
            }
        }
    }

    private static void ExecuteCarOperations(Volkswagen car)
    {
        car.StartEngine();
        car.Accelerate();
        car.Brake();
        car.StopEngine();

        QualityCheck qc = new QualityCheck();
        OrderProcessing op = new OrderProcessing();

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
