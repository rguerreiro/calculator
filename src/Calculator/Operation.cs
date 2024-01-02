namespace Calculator;

public abstract class Operation : ITerm
{
    public Operation(ITerm leftOperand, ITerm rightOperand)
    {
        LeftOperand = leftOperand;
        RightOperand = rightOperand;
    }

    public abstract string GetSymbol();
    public abstract decimal Calc();

    public ITerm LeftOperand { get; protected set; }
    public ITerm RightOperand { get; protected set; }
    public int Priority { get; protected set; } = 0;
}