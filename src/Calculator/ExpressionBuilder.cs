namespace Calculator;

public static class ExpressionBuilder
{
    private static readonly Stack<Expression> OpenedExpressions = [];

    static ExpressionBuilder()
    {
    }

    public static Expression NewExpression()
    {
        // Initialize the base expression
        OpenedExpressions.Clear();
        OpenedExpressions.Push(new Expression());
        return OpenedExpressions.Peek();
    }

    public static void AddTerm(ITerm term)
    {
        var currExpression = OpenedExpressions.Peek();
        currExpression.Add(term);
    }
}
