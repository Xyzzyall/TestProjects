// See https://aka.ms/new-console-template for more information

using CarsLib;
using CarsLib.CarTypes;

Console.WriteLine("Hello, World!");

var ford = new CarAutoType(10, 200, 120, 4);
var ford_calculator = new CarCalculator(ford);
Console.WriteLine(ford);
Console.WriteLine(ford_calculator.GetTravelDistanceInfo(ford.TankSize));

var kamaz = new LorryAutoType(20, 1500, 100, 4000);
Console.WriteLine(kamaz);
var kamaz_calc = new LorryCalculator(kamaz);
Console.WriteLine(kamaz_calc.GetTravelDistanceInfo(kamaz.TankSize));

var ferrari = new SportCarAutoType(15, 150, 300);
var ferrari_calc = new SportCarCalculator(ferrari);
Console.WriteLine(ferrari);
Console.WriteLine(ferrari_calc.GetTravelDistanceInfo(ferrari.TankSize));