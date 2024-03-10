using Calculator.Interfaces;

namespace Calculator.Operations.Notation;

public class CloseBracket : Operation, IIgnoreCalculation, ICloseExpression
{
    public CloseBracket()
        : base(")", int.MaxValue)
    {
    }

    public override double Calculate()
    {
        throw new NotImplementedException();
    }
}
