namespace Calculator.Operations.Unary;

public class FactorialOperation : UnaryOperation
{
    public FactorialOperation()
        : base('!', priority: 100)
    {
    }

    public override void PrepareForCalculation()
    {
        Operand = GetLeftOperand();
    }

    public override decimal Calculate()
    {
        ArgumentNullException.ThrowIfNull(Operand);

        var operand = Operand.Calculate();

        if (operand < 0)
            throw new ApplicationException("Cannot calculate a factorial of a negative number");

        if (!Decimal.IsInteger(operand))
            throw new ApplicationException("Factorial of numbers with decimal places isn't supported");

        decimal factorial = 1;
        while (operand > 0)
        {
            factorial *= operand;
            operand -= 1;
        }

        return factorial;
    }

    public override string ToString()
    {
        return $"{Operand}{Symbol}";
    }
}
