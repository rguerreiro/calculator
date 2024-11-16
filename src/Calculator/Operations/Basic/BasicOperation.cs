namespace Calculator.Operations.Basic;

public abstract class BasicOperation(char symbol, int priority = 1) : Operation(symbol, priority)
{
    public override void PrepareForCalculation()
    {
        LeftOperand = GetLeftOperand();
        RightOperand = GetRightOperand();
    }

    public ITerm? LeftOperand { get; protected set; } = null;

    public ITerm? RightOperand { get; protected set; } = null;

    public override string ToString()
    {
        return $"{LeftOperand} {Symbol} {RightOperand}";
    }
}
