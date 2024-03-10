namespace Calculator.Operations;

public class DivideOperation : Operation
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