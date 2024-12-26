public class Bentley : Volkswagen
{
    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} {Model}: A luxurious start...");
        Thread.Sleep(1000);
    }

    public override void Accelerate()
    {
        Console.WriteLine($"{Brand} {Model}: Accelerating with smooth power...");
        Thread.Sleep(1000);
    }

    public override void Brake()
    {
        Console.WriteLine($"{Brand} {Model}: Applying brakes with elegance...");
        Thread.Sleep(1000);
    }

    public override void StopEngine()
    {
        Console.WriteLine($"{Brand} {Model}: Shutting down the powerful engine...");
        Thread.Sleep(1000);
    }
}