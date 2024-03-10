namespace Calculator.Operations;

public abstract class Operation(string symbol, int priority = 1) : Term
{
    /**
     * Methods
     */
    public virtual void Prepare(ITerm? leftOperand, ITerm? rightOperand)
    {
        ArgumentNullException.ThrowIfNull(leftOperand);
        ArgumentNullException.ThrowIfNull(rightOperand);

        LeftOperand = leftOperand;
        LeftOperand.PartOf(this);

        RightOperand = rightOperand;
        RightOperand.PartOf(this);
    }

    /**
     * Properties
     */
    public string Symbol { get; private set; } = symbol;

    public ITerm? LeftOperand { get; protected set; } = null;

    public ITerm? RightOperand { get; protected set; } = null;

    public int Priority { get; private set; } = priority;
}