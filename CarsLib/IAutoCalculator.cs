namespace CarsLib;

public interface IAutoCalculator
{
    double GetMaxTravelDistanceInKm();
    double GetRemainTravelDistanceInKm(double fuelRemain);

    double GetHoursToTravel(double km, double fuelRemain);

    string GetTravelDistanceInfo(double fuelRemain);
}