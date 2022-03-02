using AreaLib.Models;

namespace AreaLib.Calculators;

public class TriangleByThreeSidesCalculator : IAreaCalculator<Triangle>, ITriangleIsRectangularCalculator<Triangle>
{
    private readonly Triangle _triangle;

    public TriangleByThreeSidesCalculator(Triangle triangle)
    {
        _triangle = triangle;
    }

    public double CalcArea()
    {
        var (a, b, c) = _triangle.Sides;
        var half_perimeter = (a + b + c) / 2;
        return Math.Sqrt(half_perimeter * (half_perimeter - a) * (half_perimeter - b) * (half_perimeter - c));
    }
    
    public bool IsRectangular()
    {
        var (a, b, c) = _triangle.Sides;

        if (a >= b && a >= c)
        {
            return Math.Abs(a * a - (b * b + c * c)) < 0.00001f;
        }
        
        if (b >= a && b >= c)
        {
            return Math.Abs(b * b - (a * a + c * c)) < 0.00001f;
        }
        
        return Math.Abs(c * c - (b * b + a * a)) < 0.00001f;
    }
}