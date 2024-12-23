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