namespace Calculator.Operations.Notation;

public class CloseBracket : TerminalExpression
{
    public CloseBracket()
        : base(")", int.MaxValue)
    {
    }
}
