using System;

public class Program
{
    public static void Main(string[] args)
    {
        string? BrandName;
        string? ModelName;

        while (true)
        {
            Console.WriteLine("Enter brand name (Bentley, Audi, Skoda, Lamborghini, Porsche) or 'exit' to quit: ");
            BrandName = Console.ReadLine()!;
            if (BrandName.ToLower() == "exit")
                break;

            Console.WriteLine("Enter model name: ");
            ModelName = Console.ReadLine()!;

            IVehicle? car = BrandName.ToLower() switch
            {
                "bentley" => new Bentley { Brand = "Bentley", Model = ModelName },
                "audi" => new Audi { Brand = "Audi", Model = ModelName },
                "skoda" => new Skoda { Brand = "Skoda", Model = ModelName },
                "lamborghini" => new Lamborghini { Brand = "Lamborghini", Model = ModelName },
                "porsche" => new Porsche { Brand = "Porsche", Model = ModelName },
                _ => null
            };

            if (car != null)
            {
                ExecuteCarOp executeCarOp = new ExecuteCarOp();
                executeCarOp.ExecuteCarOperations(car);
            }
            else if (car == null)
            {
                Console.WriteLine("Invalid brand name. Please enter a valid brand.");
            }
        }
    }
}