namespace Calculator.Operations.Basic;

public class PowerOperation : BasicOperation
{
    public PowerOperation()
        : base("^", priority: 3)
    {
    }

    public override decimal Calculate()
    {
        ArgumentNullException.ThrowIfNull(LeftOperand);
        ArgumentNullException.ThrowIfNull(RightOperand);

        return (decimal)Math.Pow(Decimal.ToDouble(LeftOperand.Calculate()), Decimal.ToDouble(RightOperand.Calculate()));
    }
}
