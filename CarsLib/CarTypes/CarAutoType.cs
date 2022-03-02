namespace CarsLib.CarTypes;

public record CarAutoType
(
    double AvgFuelConsumptionPer100Km, 
    double TankSize, 
    double Speed,
    int MaxPassengers
) : GenericAutoType(CarType.Car, AvgFuelConsumptionPer100Km, TankSize, Speed);