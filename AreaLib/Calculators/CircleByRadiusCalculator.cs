using AreaLib.Models;

namespace AreaLib.Calculators;

public class CircleByRadiusCalculator : IAreaCalculator<Circle>
{
    private readonly Circle _circle;
    public CircleByRadiusCalculator(Circle circle)
    {
        _circle = circle;
    }
    
    public double CalcArea()
    {
        return Math.PI * _circle.Radius * _circle.Radius;
    }
}