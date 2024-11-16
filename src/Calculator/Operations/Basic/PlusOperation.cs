namespace Calculator.Operations.Basic;

public class PlusOperation : BasicOperation
{
    public PlusOperation()
        : base("+")
    {
    }

    public override decimal Calculate()
    {
        ArgumentNullException.ThrowIfNull(LeftOperand);
        ArgumentNullException.ThrowIfNull(RightOperand);

        return LeftOperand.Calculate() + RightOperand.Calculate();
    }
}
