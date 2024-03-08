namespace Calculator.Operations;

public class PlusOperation : Operation
{
    public PlusOperation()
        :base("+")
    {
    }

    public override decimal Calc()
    {
        ArgumentNullException.ThrowIfNull(LeftOperand);
        ArgumentNullException.ThrowIfNull(RightOperand);

        return LeftOperand.Calc() + RightOperand.Calc();
    }
}
