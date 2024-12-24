using System;

public class Triangle
{
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double a, double b, double c)
    {
        if (IsTriangle(a, b, c))
        {
            this.sideA = a;
            this.sideB = b;
            this.sideC = c;
        }
        else
        {
             Console.WriteLine("Стороны не могут образовать треугольник.");
        }
    }
    private bool IsTriangle(double a, double b, double c)
    {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }

    public double Perimeter() 
    {
        return sideA+sideB+sideC;
    }

    public virtual double SquareT() 
    {
        {
            double semiPerimeter = Perimeter() / 2;
            double result = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
            return result;
        }
    }
}

class Pyramid : Triangle 
{
    private double h;

    public Pyramid(double a, double b, double c, double h) : base(a, b, c)
    {
        this.h = h;
    }

    internal double SquareSide() 
    {
        return base.Perimeter() * 0.5 * h;
    }
    public override double SquareT()
    {
        return base.SquareT() + (SquareSide() * 3);

    }

}

class Prism : Triangle 
{
    private double h;

    public Prism(double a, double b, double c, double h) : base(a, b, c)
    {
        this.h = h;
    }
    internal double SquareSide()
    {
        return base.Perimeter() * h;
    }
    public override double SquareT()
    {
        return (base.SquareT() * 2) + SquareSide();
    }
}

class Program 
{
    static void Main() 
    {
        Console.WriteLine("Выберете фигуру с которой хотите работать:");
        Console.WriteLine("1. Треугольник");
        Console.WriteLine("2. Пирамида");
        Console.WriteLine("3. Треугольная призма");

        int choise = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите стороны треугольника (a,b,c): ");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());

        switch (choise)
        {
            case 1:
                Triangle triangle = new Triangle(a, b, c);
                Console.WriteLine($"Периметр треугольника: {triangle.Perimeter()}");
                Console.WriteLine($"Площадь треугольника: {triangle.SquareT()}");
                break;

            case 2:
                Console.WriteLine("Введите высоту пиромиды: ");
                double hp = Convert.ToDouble(Console.ReadLine());
                
                Pyramid pyramid = new Pyramid(a,b,c,hp);
                Console.WriteLine($"Площадь пиромиды: {pyramid.SquareT()}");
                Console.WriteLine($"Площадь боковой поверхности: {pyramid.SquareSide()}");
                break;

            case 3:
                Console.WriteLine("Введите высоту треугольной призмы: ");
                double hpr = Convert.ToDouble(Console.ReadLine());

                Prism prism = new Prism(a,b,c,hpr);
                Console.WriteLine($"Площадь призмы: {prism.SquareT()}");
                Console.WriteLine($"Площадь боковой поверхности: {prism.SquareSide()}");

                break;
        }
    }
}
