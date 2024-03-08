namespace Calculator.Operations;

public class MinusOperation : Operation
{
    public MinusOperation()
        : base("-")
    {
    }

    public override decimal Calc()
    {
        ArgumentNullException.ThrowIfNull(LeftOperand);
        ArgumentNullException.ThrowIfNull(RightOperand);

        return LeftOperand.Calc() - RightOperand.Calc();
    }
}
