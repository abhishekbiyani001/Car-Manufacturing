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
        Console.WriteLine("Volkswagen engine started...");
    }

    public virtual void StopEngine()
    {
        Console.WriteLine("Volkswagen engine stopped...");
    }

    public virtual void Accelerate()
    {
        Console.WriteLine("Volkswagen accelerating...");
    }

    public virtual void Brake()
    {
        Console.WriteLine("Volkswagen braking...");
    }
}

public class BMW : Volkswagen
{
    public override void StartEngine()
    {
        Console.WriteLine("BMW engine roaring...");
    }

    public override void StopEngine()
    {
        Console.WriteLine("BMW engine stopped...");
    }

    public override void Accelerate()
    {
        Console.WriteLine("BMW accelerating...");
    }

    public override void Brake()
    {
        Console.WriteLine("BMW braking...");
    }
}

public class Audi : Volkswagen
{
    public override void StartEngine()
    {
        Console.WriteLine("Audi engine started...");
    }

    public override void StopEngine()
    {
        Console.WriteLine("Audi engine stopped...");
    }

    public override void Accelerate()
    {
        Console.WriteLine("Audi accelerating...");
    }

    public override void Brake()
    {
        Console.WriteLine("Audi braking...");
    }
}

public class Mercedes : Volkswagen
{
    public override void StartEngine()
    {
        Console.WriteLine("Mercedes engine started...");
    }

    public override void StopEngine()
    {
        Console.WriteLine("Mercedes engine stopped...");
    }

    public override void Accelerate()
    {
        Console.WriteLine("Mercedes accelerating...");
    }

    public override void Brake()
    {
        Console.WriteLine("Mercedes braking...");
    }
}

public class QualityCheck
{
    public delegate void QualityCheckDelegate(Volkswagen car);
    public event QualityCheckDelegate? QualityCheckEvent;

    public void CheckQuality(Volkswagen car)
    {
        Console.WriteLine();
        Console.WriteLine("Performing quality check...");
        QualityCheckEvent?.Invoke(car);
        Console.WriteLine();
    }
}

public class OrderProcessing
{
    public delegate void OrderProcessingDelegate(Volkswagen car);
    public event OrderProcessingDelegate? OrderProcessedEvent;

    public void ProcessOrder(Volkswagen car)
    {
        Console.WriteLine("Processing order...");
        OrderProcessedEvent?.Invoke(car);
        Console.WriteLine();
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter BMW model name: ");
        string ModelName = Console.ReadLine();
        Volkswagen car = new BMW { Brand = "BMW", Model = ModelName };
        car.StartEngine();
        car.Accelerate();
        car.Brake();
        car.StopEngine();

        QualityCheck qc = new QualityCheck();
        qc.QualityCheckEvent += car => Console.WriteLine($"Quality check completed for {car.Brand} {car.Model}");

        OrderProcessing op = new OrderProcessing();
        op.OrderProcessedEvent += car => Console.WriteLine($"Order processed for {car.Brand} {car.Model}");

        qc.CheckQuality(car);
        op.ProcessOrder(car);
        Thread.Sleep(1000);

        Console.WriteLine("Enter Audi model name: ");
        ModelName = Console.ReadLine();
        car = new Audi { Brand = "Audi", Model = ModelName };
        car.StartEngine();
        car.Accelerate();
        car.Brake();
        car.StopEngine();

        qc.CheckQuality(car);
        op.ProcessOrder(car);

        //car = new Mercedes { Brand = "Mercedes", Model = " Maybach GLS" };
        //qc.CheckQuality(car);
        //op.ProcessOrder(car);

        qc.QualityCheckEvent -= car => Console.WriteLine($"Quality check completed for {car.Brand} {car.Model}");
        op.OrderProcessedEvent -= car => Console.WriteLine($"Order processed for {car.Brand} {car.Model}");
    }
}