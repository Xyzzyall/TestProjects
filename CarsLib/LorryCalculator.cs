using System.Text;
using CarsLib.CarTypes;

namespace CarsLib;

public class LorryCalculator : IAutoCalculator
{
    private readonly LorryAutoType _lorryAuto;

    public LorryCalculator(LorryAutoType lorryAuto)
    {
        _lorryAuto = lorryAuto;
    }

    public double CurrentLoad { get; private set; }

    public bool SetCurrentLoad(double currentLoad)
    {
        if (currentLoad > _lorryAuto.LoadCapacityKg)
            return false;
        CurrentLoad = currentLoad;
        return true;
    }

    public double GetMaxTravelDistanceInKm()
    {
        return GetRemainTravelDistanceInKm(_lorryAuto.TankSize);
    }

    public double GetRemainTravelDistanceInKm(double fuelRemain)
    {
        return CalculateRemainTravelDistInKm(fuelRemain, _lorryAuto.AvgFuelConsumptionPer100Km, CurrentLoad);
    }
    
    private static double CalculateRemainTravelDistInKm(double fuelRemain, double avgFuelConsumptionPer100Km, double currentLoad)
    {
        return 100 * (fuelRemain / avgFuelConsumptionPer100Km) * Math.Pow(0.96, currentLoad / 200);
    }

    public double GetHoursToTravel(double km, double fuelRemain)
    {
        if (GetRemainTravelDistanceInKm(fuelRemain) < km)
            return double.PositiveInfinity;
        return km / _lorryAuto.Speed;
    }

    public string GetTravelDistanceInfo(double fuelRemain)
    {
        var res = new StringBuilder("Load\t|\tRemain distance").AppendLine();
        for (var load = 0; load <= _lorryAuto.LoadCapacityKg; load+=200)
        {
            var distance = Math.Round(CalculateRemainTravelDistInKm(fuelRemain, _lorryAuto.AvgFuelConsumptionPer100Km, load), 3);
            res.AppendLine($"{load} kg\t|\t{distance} km");
        }
        return res.ToString();
    }
}