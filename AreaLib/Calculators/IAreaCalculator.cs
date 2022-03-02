using AreaLib.Models;

namespace AreaLib.Calculators;

public interface IAreaCalculator<TFigure> : IAreaCalculatorWithoutGeneric
where TFigure : IHasArea
{

}

public interface IAreaCalculatorWithoutGeneric
{
    public double CalcArea();
}

public interface ITriangleIsRectangularCalculator<TFigure> : ITriangleIsRectangularCalculatorWithoutGeneric
where TFigure : ITriangle
{
    
}

public interface ITriangleIsRectangularCalculatorWithoutGeneric
{
    public bool IsRectangular();
}