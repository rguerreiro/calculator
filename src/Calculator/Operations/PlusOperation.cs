namespace Calculator.Operations;

public class PlusOperation : Operation
{
    public PlusOperation()
        :base("+")
    {
    }

    public override decimal Calculate()
    {
        ArgumentNullException.ThrowIfNull(LeftOperand);
        ArgumentNullException.ThrowIfNull(RightOperand);

        return LeftOperand.Calculate() + RightOperand.Calculate();
    }
}
