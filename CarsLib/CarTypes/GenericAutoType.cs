namespace CarsLib.CarTypes;

public record GenericAutoType
(
    GenericAutoType.CarType Type,
    double AvgFuelConsumptionPer100Km,
    double TankSize,
    double Speed
)
{
    public enum CarType
    {
        Lorry,
        Car,
        SportCar
    }
};

