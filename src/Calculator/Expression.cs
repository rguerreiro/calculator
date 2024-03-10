using Calculator.Operations;

namespace Calculator;

public class Expression
{    
    private readonly List<ITerm> _terms = [];
    private readonly Stack<Expression> _openedExpressions = [];

    public Expression Add(ITerm term)
    {
        if(_openedExpressions.Count > 0)
        {
            var subExpression = _openedExpressions.Peek();
            subExpression.Add(term);
            return subExpression;
        }

        _terms.Add(term);
        term.Id = Count;

        term.PartOf(this);

        return this;
    }

    public decimal Calculate()
    {
        // sort by the operation that has more priority
        var operations = _terms.Where(x => x is Operation).Cast<Operation>()
            .OrderByDescending(x => x.Priority)
            .ThenBy(x => x.Id).ToList();

        foreach(var op in operations)
        {
            op.PrepareForCalculation();
        }

        // Go to the last operation to start the calculation,
        // which is the one that all depends and it depends on no one
        return operations.Last().Calculate();
    }

    public virtual Expression OpenSubExpresssion()
    {
        var subExpression = new Expression();
        _openedExpressions.Push(subExpression);
        return subExpression;
    }

    public virtual Expression CloseSubExpression()
    {
        return _openedExpressions.Pop();
    }

    public virtual ITerm? GetLeftOperandOf(Operation operation)
    {
        var left = _terms.First(x => x.Id == operation.Id - 1);
        while (left != null && left.Captured) left = left.BelongsTo;
        return left;
    }

    public virtual ITerm? GetRightOperandOf(Operation operation)
    {
        var right = _terms.First(x => x.Id == operation.Id + 1);
        while (right != null && right.Captured) right = right.BelongsTo;
        return right;
    }

    public int Count { get { return _terms.Count; } }
}
