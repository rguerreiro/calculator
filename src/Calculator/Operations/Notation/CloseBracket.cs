using Calculator.Interfaces;

namespace Calculator.Operations.Notation;

public class CloseBracket : Operation, IIgnoreCalculation
{
    public CloseBracket()
        : base(")", 3)
    {
    }

    public override void PartOf(Expression expression)
    {
        base.PartOf(expression);

        ArgumentNullException.ThrowIfNull(expression);
        ArgumentNullException.ThrowIfNull(ParentExpression);

        ParentExpression.CloseSubExpression();
    }

    public override decimal Calculate()
    {
        throw new NotImplementedException();
    }
}
