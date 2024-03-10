namespace Calculator.Numbers;

public class Number(decimal value) : Term
{
    public override decimal Calc()
    {
        return Value;
    }

    public decimal Value { get; private set; } = value;
}