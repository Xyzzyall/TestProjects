using System.Diagnostics;

namespace CarsLib.CarTypes;

public record LorryAutoType : GenericAutoType
{
    public LorryAutoType(double avgFuelConsumptionPer100Km, 
        double tankSize, 
        double speed,
        double loadCapacityKg) : base(CarType.Lorry, avgFuelConsumptionPer100Km, tankSize, speed)
    {
        Debug.Assert(loadCapacityKg > 0);
        this.LoadCapacityKg = loadCapacityKg;
    }

    public double LoadCapacityKg { get; init; }

    public void Deconstruct(out double AvgFuelConsumptionPer100Km, out double TankSize, out double Speed, out double LoadCapacityKg)
    {
        AvgFuelConsumptionPer100Km = this.AvgFuelConsumptionPer100Km;
        TankSize = this.TankSize;
        Speed = this.Speed;
        LoadCapacityKg = this.LoadCapacityKg;
    }
}