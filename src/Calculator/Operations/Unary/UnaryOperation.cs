namespace Calculator.Operations.Unary;

public abstract class UnaryOperation(char symbol, int priority = 1) : Operation(symbol, priority)
{
    public abstract override void PrepareForCalculation();

    public ITerm? Operand { get; protected set; } = null;

    public abstract override string ToString();
}
