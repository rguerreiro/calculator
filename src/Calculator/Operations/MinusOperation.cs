namespace Calculator.Operations;

public class MinusOperation : Operation
{
    public MinusOperation()
        : base("-")
    {
    }

    public override decimal Calculate()
    {
        ArgumentNullException.ThrowIfNull(LeftOperand);
        ArgumentNullException.ThrowIfNull(RightOperand);

        return LeftOperand.Calculate() - RightOperand.Calculate();
    }
}
