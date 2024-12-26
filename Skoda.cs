public class Skoda : Volkswagen
{
    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} {Model}: Reliable engine start...");
        Thread.Sleep(500);
    }

    public override void Accelerate()
    {
        Console.WriteLine($"{Brand} {Model}: Accelerating efficiently...");
        Thread.Sleep(500);
    }

    public override void Brake()
    {
        Console.WriteLine($"{Brand} {Model}: Braking securely...");
        Thread.Sleep(500);
    }

    public override void StopEngine()
    {
        Console.WriteLine($"{Brand} {Model}: Engine stopped with dependability...");
        Thread.Sleep(500);
    }
}