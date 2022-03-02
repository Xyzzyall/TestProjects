using System.Diagnostics;
using System.Reflection;
using AreaLib.Calculators;
using AreaLib.Models;

namespace AreaLib;

public static class AreaLib
{
    public static double CalcArea(this IHasArea figure)
    {
        var calculator_type = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.GetInterfaces().Any(
                    t=> t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IAreaCalculator<>) && t.GetGenericArguments().Contains(figure.GetType())
                )
            );
        Debug.Assert(calculator_type is not null);

        var maybe_calc = calculator_type.GetConstructor(new[]{figure.GetType()})?.Invoke(new object[]{figure});
        Debug.Assert(maybe_calc is IAreaCalculatorWithoutGeneric);
        return (maybe_calc as IAreaCalculatorWithoutGeneric)!.CalcArea();

        // Задачу можно решить без рефлексии (через патерн матчинг), это быстрее, однако это небольшое нарушение Open-Closed 
        // (скорость рефлексии можно увеличить, если assembly scan кэшировать)
        // switch (figure)
        // {
        //     case Circle circle:
        //         return Math.PI * Math.Pow( circle.Radius, 2);
        //     case Triangle triangle:
        //         var (a, b, c) = triangle.Sides;
        //         var half_perimeter = (a + b + c) / 2;
        //         return Math.Sqrt(half_perimeter * (half_perimeter - a) * (half_perimeter - b) * (half_perimeter - c));
        // }
        //
        // throw new NotImplementedException();
    }

    public static bool IsRectangular(this ITriangle triangle)
    {
        var calculator_type = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.GetInterfaces().Any(
                    t=> t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ITriangleIsRectangularCalculator<>) && t.GetGenericArguments().Contains(triangle.GetType())
                )
            );
        Debug.Assert(calculator_type is not null);

        var maybe_calc = calculator_type.GetConstructor(new[]{triangle.GetType()})?.Invoke(new object[]{triangle});
        Debug.Assert(maybe_calc is IAreaCalculatorWithoutGeneric);
        return (maybe_calc as ITriangleIsRectangularCalculatorWithoutGeneric)!.IsRectangular();
    }
}