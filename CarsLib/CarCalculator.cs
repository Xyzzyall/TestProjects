using System.Text;
using CarsLib.CarTypes;

namespace CarsLib;

public class CarCalculator : IAutoCalculator
{
    private readonly CarAutoType _car;

    public CarCalculator(CarAutoType car)
    {
        _car = car;
    }

    public int Passengers { get; private set; }

    public bool SetPassengers(int passengers)
    {
        if (passengers > _car.MaxPassengers)
            return false;
        Passengers = passengers;
        return true;
    }
    
    public double GetMaxTravelDistanceInKm()
    {
        return GetRemainTravelDistanceInKm(_car.TankSize);
    }

    public double GetRemainTravelDistanceInKm(double fuelRemain)
    {
        return CalculateRemainTravelDistInKm(fuelRemain, _car.AvgFuelConsumptionPer100Km, Passengers);
    }

    private static double CalculateRemainTravelDistInKm(double fuelRemain, double avgFuelConsumptionPer100Km, int passengers)
    {
        return 100 * (fuelRemain / avgFuelConsumptionPer100Km) * Math.Pow(0.94, passengers);
    }

    public double GetHoursToTravel(double km, double fuelRemain)
    {
        if (GetRemainTravelDistanceInKm(fuelRemain) < km)
            return double.PositiveInfinity;
        return km / _car.Speed;
    }

    public string GetTravelDistanceInfo(double fuelRemain)
    {
        var res = new StringBuilder("Passengers\t|\tRemain distance").AppendLine();
        for (var i = 0; i <= _car.MaxPassengers; i++)
        {
            var distance = Math.Round(CalculateRemainTravelDistInKm(fuelRemain, _car.AvgFuelConsumptionPer100Km, i), 3);
            res.AppendLine($"{i}\t|\t{distance} km");
        }
        return res.ToString();
    }
}