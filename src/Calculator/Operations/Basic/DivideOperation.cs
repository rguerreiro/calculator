namespace Calculator.Operations.Basic;

public class DivideOperation : BasicOperation
{
    public DivideOperation()
        : base("/", priority: 2)
    {
    }

    public override decimal Calculate()
    {
        ArgumentNullException.ThrowIfNull(LeftOperand);
        ArgumentNullException.ThrowIfNull(RightOperand);

        return LeftOperand.Calculate() / RightOperand.Calculate();
    }
}