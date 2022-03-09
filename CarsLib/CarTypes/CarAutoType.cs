using System.Diagnostics;

namespace CarsLib.CarTypes;

public record CarAutoType : GenericAutoType
{
    public CarAutoType(double avgFuelConsumptionPer100Km, 
        double tankSize, 
        double speed,
        int maxPassengers) : base(CarType.Car, avgFuelConsumptionPer100Km, tankSize, speed)
    {
        Debug.Assert(maxPassengers > 0);
        this.MaxPassengers = maxPassengers;
    }

    public int MaxPassengers { get; }

    public void Deconstruct(out double AvgFuelConsumptionPer100Km, out double TankSize, out double Speed, out int MaxPassengers)
    {
        AvgFuelConsumptionPer100Km = this.AvgFuelConsumptionPer100Km;
        TankSize = this.TankSize;
        Speed = this.Speed;
        MaxPassengers = this.MaxPassengers;
    }
}