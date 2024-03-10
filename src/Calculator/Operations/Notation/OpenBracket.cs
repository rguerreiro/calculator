using Calculator.Interfaces;

namespace Calculator.Operations.Notation;

public class OpenBracket : Operation, IHasExpression
{
    public OpenBracket()
        : base("(", 3)
    {
    }

    public override void PartOf(Expression expression)
    {
        base.PartOf(expression);

        ArgumentNullException.ThrowIfNull(expression);
        ArgumentNullException.ThrowIfNull(ParentExpression);

        Expression = ParentExpression.OpenSubExpresssion();
    }

    public override decimal Calculate()
    {
        return Expression.Calculate();
    }

    public Expression Expression { get; protected set; }
}
