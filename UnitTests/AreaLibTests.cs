using System;
using AreaLib;
using AreaLib.Models;
using Xunit;

namespace AreaLibTests;

public class AreaLibTests
{        
    private const double Error = 0.00000001d;
    [Theory]
    [InlineData(1, Math.PI)]
    [InlineData(2, 2*2*Math.PI)]
    public void CalcArea_ShouldCalcCorrectAreaOfCircle(float radius, double expectedArea)
    {
        var circle = new Circle(radius);

        var area = circle.CalcArea();
        
        Assert.True(Math.Abs(area - expectedArea) < Error);
    }

    [Theory]
    [InlineData(3, 4, 5, 6)]
    public void CalcArea_ShouldCalcCorrectAreaOfTriangle(float a, float b, float c, double expectedArea)
    {
        var triangle = new Triangle(a, b, c);

        var area = triangle.CalcArea();
        
        Assert.True(Math.Abs(area - expectedArea) < Error);
    }

    [Theory]
    [InlineData(1, 1, 1, false)]
    [InlineData(1, 1, 1.41421356237, true)]
    [InlineData(1, 1.41421356237, 1, true)]
    public void IsRectangular_ShouldBeCorrect(float a, float b, float c, bool expectedResult)
    {
        var triangle = new Triangle(a, b, c);

        var res = triangle.IsRectangular();
        
        Assert.Equal(expectedResult, res);
    }
}