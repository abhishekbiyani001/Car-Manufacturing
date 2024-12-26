using System;
using System.Threading;

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
        Logger.Log($"{Brand} {Model}: Engine started.");
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