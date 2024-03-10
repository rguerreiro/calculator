namespace Calculator.Numbers;

public class Number(decimal value) : Term
{
    public override decimal Calculate()
    {
        return Value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public decimal Value { get; private set; } = value;
}