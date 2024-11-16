using Calculator.Interfaces;

namespace Calculator.Numbers;

public abstract class Constant(string symbol, decimal value) : Number(value), IConstant
{
    public override string ToString()
    {
        return Symbol;
    }

    public string Symbol { get; private set; } = symbol;
}
