namespace CarsLib.CarTypes;

public record SportCarAutoType(
    double AvgFuelConsumptionPer100Km, 
    double TankSize, 
    double Speed
) : GenericAutoType(CarType.SportCar, AvgFuelConsumptionPer100Km, TankSize, Speed);