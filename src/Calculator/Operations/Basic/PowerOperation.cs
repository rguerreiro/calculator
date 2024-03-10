namespace Calculator.Operations.Basic;

public class PowerOperation : BasicOperation
{
    public PowerOperation()
        : base("^", priority: 3)
    {
    }

    public override double Calculate()
    {
        ArgumentNullException.ThrowIfNull(LeftOperand);
        ArgumentNullException.ThrowIfNull(RightOperand);

        return Math.Pow(LeftOperand.Calculate(), RightOperand.Calculate());
    }
}
