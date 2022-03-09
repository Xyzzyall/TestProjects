using System.Diagnostics;

namespace AreaLib.Models;

public class Triangle : ITriangle
{
    public Triangle(float a, float b, float c)
    {
        Debug.Assert(a > 0 && b > 0 && c > 0);
        Sides = (a, b, c);
    }
    
    public (float, float, float) Sides { get; }
}