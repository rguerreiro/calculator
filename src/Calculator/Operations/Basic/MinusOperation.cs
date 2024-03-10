namespace Calculator.Operations.Basic;

public class MinusOperation : BasicOperation
{
    public MinusOperation()
        : base("-")
    {
    }

    public override double Calculate()
    {
        ArgumentNullException.ThrowIfNull(LeftOperand);
        ArgumentNullException.ThrowIfNull(RightOperand);

        return LeftOperand.Calculate() - RightOperand.Calculate();
    }
}
