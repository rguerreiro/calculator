using Calculator.Interfaces;

namespace Calculator.Operations.Notation;

public class OpenBracket : Operation, IHasExpression
{
    public OpenBracket()
        : base("(", int.MaxValue)
    {
    }

    public override void PrepareForCalculation()
    {
        ArgumentNullException.ThrowIfNull(Expression);

        Expression.Build();
    }

    public override void PartOf(Expression expression)
    {
        base.PartOf(expression);

        ArgumentNullException.ThrowIfNull(expression);
        ArgumentNullException.ThrowIfNull(ParentExpression);

        Expression = ParentExpression.OpenSubExpresssion(this);
    }

    public override double Calculate()
    {
        ArgumentNullException.ThrowIfNull(Expression);

        return Expression.Calculate();
    }

    public Expression? Expression { get; protected set; }

    public override string ToString()
    {
        return $"({Expression})";
    }
}
