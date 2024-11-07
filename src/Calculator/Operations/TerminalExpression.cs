using Calculator.Interfaces;

namespace Calculator.Operations;

public abstract class TerminalExpression(string symbol, int priority) : Operation(symbol, priority), ITerminalExpression
{
    public override double Calculate()
    {
        // It should not be called in any circumstances. If called then something really wrong happened.
        throw new ApplicationException($"Unable to calculate in a terminal expression: '{this.Symbol}'");
    }
}