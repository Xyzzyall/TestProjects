namespace CarsLib.CarTypes;

public record LorryAutoType
(
    double AvgFuelConsumptionPer100Km, 
    double TankSize, 
    double Speed,
    double LoadCapacityKg
) : GenericAutoType(CarType.Lorry, AvgFuelConsumptionPer100Km, TankSize, Speed);