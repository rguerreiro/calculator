
using Calculator.Operations;

namespace Calculator;

public class Expression
{    
    private readonly List<ITerm> _terms = [];

    public Expression Add(ITerm term)
    {
        _terms.Add(term);
        term.Id = Count;
        return this;
    }

    public decimal Calculate()
    {
        var operations = _terms.Where(x => x is Operation).Cast<Operation>()
            .OrderByDescending(x => x.Priority)
            .ThenBy(x => x.Id).ToList();

        foreach (var op in operations)
        {
            var left = _terms.First(x => x.Id == op.Id - 1);
            var right = _terms.First(x => x.Id == op.Id + 1);

            while (left != null && left.Captured) left = left.BelongsTo;
            while (right != null && right.Captured) right = right.BelongsTo;

            op.Prepare(left, right);
        }

        return operations.Last().Calc();
    }

    public int Count { get { return _terms.Count; } }
}
