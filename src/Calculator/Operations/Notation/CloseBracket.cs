namespace Calculator.Operations.Notation;

public class CloseBracket : TerminalExpression
{
    public CloseBracket()
        : base(')', int.MaxValue)
    {
    }

    public override string ToString()
    {
        // The open bracket "(" returns the complete string
        return ")";
    }
}
