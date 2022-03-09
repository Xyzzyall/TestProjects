using System.Diagnostics;

namespace AreaLib.Models;

public class Circle : IHasArea
{
    public Circle(float radius)
    {
        Debug.Assert(radius > 0);
        Radius = radius;
    }
    public float Radius { get; }
}