using System;

public class SimpleFraction
{
    private int _numerator;
    private int _denominator;

    public SimpleFraction()
    {
        // Default to 1/1
        _numerator = 1;
        _denominator = 1;
    }

    public SimpleFraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _denominator = 1;
    }

    public SimpleFraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }

        _numerator = numerator;
        _denominator = denominator;
    }

    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}

class Program
{
    static void Main(string[] args)
    {
        SimpleFraction f1 = new SimpleFraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        SimpleFraction f2 = new SimpleFraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        SimpleFraction f3 = new SimpleFraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        SimpleFraction f4 = new SimpleFraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());
    }
}
