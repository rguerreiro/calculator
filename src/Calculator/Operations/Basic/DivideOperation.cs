namespace Calculator.Operations.Basic;

public class DivideOperation : BasicOperation
{
    public DivideOperation()
        : base('/', priority: 2)
    {
    }

    public override decimal Calculate()
    {
        ArgumentNullException.ThrowIfNull(LeftOperand);
        ArgumentNullException.ThrowIfNull(RightOperand);

        if (RightOperand.Calculate() == 0)
            throw new ApplicationException("Cannot divide by zero");

        return LeftOperand.Calculate() / RightOperand.Calculate();
    }
}