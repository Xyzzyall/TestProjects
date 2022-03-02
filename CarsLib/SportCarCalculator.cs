using CarsLib.CarTypes;

namespace CarsLib;

public class SportCarCalculator : IAutoCalculator
{
    private readonly SportCarAutoType _sportCar;

    public SportCarCalculator(SportCarAutoType sportCar)
    {
        _sportCar = sportCar;
    }

    public double GetMaxTravelDistanceInKm()
    {
        return GetRemainTravelDistanceInKm(_sportCar.TankSize);
    }

    public double GetRemainTravelDistanceInKm(double fuelRemain)
    {
        return 100 * (fuelRemain / _sportCar.AvgFuelConsumptionPer100Km);
    }

    public double GetHoursToTravel(double km, double fuelRemain)
    {
        if (GetRemainTravelDistanceInKm(fuelRemain) < km)
            return double.PositiveInfinity;
        return km / _sportCar.Speed;
    }

    public string GetTravelDistanceInfo(double fuelRemain)
    {
        return $"Remain distance is {Math.Round(GetRemainTravelDistanceInKm(fuelRemain), 3)} km";
    }
}