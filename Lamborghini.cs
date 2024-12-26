public class Lamborghini : Volkswagen
{
    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} {Model}: VROOM! The beast awakens...");
        Thread.Sleep(1500);
    }

    public override void Accelerate()
    {
        Console.WriteLine($"{Brand} {Model}: Accelerating at lightning speed...");
        Thread.Sleep(1500);
    }

    public override void Brake()
    {
        Console.WriteLine($"{Brand} {Model}: Braking like a racecar...");
        Thread.Sleep(1500);
    }

    public override void StopEngine()
    {
        Console.WriteLine($"{Brand} {Model}: The beast goes to sleep...");
        Thread.Sleep(1500);
    }
}