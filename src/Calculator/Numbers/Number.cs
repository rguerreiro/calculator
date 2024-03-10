namespace Calculator.Numbers;

public class Number(double value) : Term
{
    public override double Calculate()
    {
        return Value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public double Value { get; private set; } = value;
}