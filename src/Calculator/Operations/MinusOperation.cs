namespace Calculator.Operations;

public class MinusOperation : Operation
{
    public MinusOperation(ITerm leftOperand, ITerm rightOperand)
        : base(leftOperand, rightOperand)
    {
    }

    public override decimal Calc()
    {
        return LeftOperand.Calc() - RightOperand.Calc();
    }

    public override string GetSymbol()
    {
        return "-";
    }
}
