namespace Calculator.Operations;

public class MultiplyOperation : Operation
{
    public MultiplyOperation(ITerm leftOperand, ITerm rightOperand)
        : base(leftOperand, rightOperand)
    {
        Priority = 1;
    }

    public override decimal Calc()
    {
        return LeftOperand.Calc() * RightOperand.Calc();
    }

    public override string GetSymbol()
    {
        return "x";
    }
}