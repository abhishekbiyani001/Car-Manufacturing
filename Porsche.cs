public class Porsche : Volkswagen
{
    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} {Model}: A perfect start with roaring precision...");
        Thread.Sleep(1250);
    }

    public override void Accelerate()
    {
        Console.WriteLine($"{Brand} {Model}: Accelerating with unmatched speed...");
        Thread.Sleep(1250);
    }

    public override void Brake()
    {
        Console.WriteLine($"{Brand} {Model}: Braking with finesse...");
        Thread.Sleep(1250);
    }

    public override void StopEngine()
    {
        Console.WriteLine($"{Brand} {Model}: Engine stopped seamlessly...");
        Thread.Sleep(1250);
    }
}