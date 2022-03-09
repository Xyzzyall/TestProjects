using System.Diagnostics;

namespace CarsLib.CarTypes;

public record GenericAutoType
{
    public GenericAutoType(GenericAutoType.CarType type,
        double avgFuelConsumptionPer100Km,
        double tankSize,
        double speed)
    {
        Debug.Assert(avgFuelConsumptionPer100Km > 0);
        Debug.Assert(tankSize > 0);
        Debug.Assert(speed > 0);
        
        this.Type = type;
        this.AvgFuelConsumptionPer100Km = avgFuelConsumptionPer100Km;
        this.TankSize = tankSize;
        this.Speed = speed;
    }

    public enum CarType
    {
        Lorry,
        Car,
        SportCar
    }

    public GenericAutoType.CarType Type { get; init; }
    public double AvgFuelConsumptionPer100Km { get; init; }
    public double TankSize { get; init; }
    public double Speed { get; init; }

    public void Deconstruct(out GenericAutoType.CarType Type, out double AvgFuelConsumptionPer100Km, out double TankSize, out double Speed)
    {
        Type = this.Type;
        AvgFuelConsumptionPer100Km = this.AvgFuelConsumptionPer100Km;
        TankSize = this.TankSize;
        Speed = this.Speed;
    }
};

