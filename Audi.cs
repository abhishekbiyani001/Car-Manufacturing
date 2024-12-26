public class Audi : Volkswagen
{
    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} {Model}: Engine roars with precision...");
        Thread.Sleep(750);
    }

    public override void Accelerate()
    {
        Console.WriteLine($"{Brand} {Model}: Accelerating with quattro power...");
        Thread.Sleep(750);
    }

    public override void Brake()
    {
        Console.WriteLine($"{Brand} {Model}: Smooth braking with advanced technology...");
        Thread.Sleep(750);
    }

    public override void StopEngine()
    {
        Console.WriteLine($"{Brand} {Model}: Engine stopped gracefully...");
        Thread.Sleep(750);
    }
}
