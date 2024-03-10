using Calculator.Interfaces;

namespace Calculator.Operations.Notation;

public class CloseBracket : Operation, IIgnoreCalculation, ICloseExpression
{
    public CloseBracket()
        : base(")", 3)
    {
    }

    public override decimal Calculate()
    {
        throw new NotImplementedException();
    }
}
