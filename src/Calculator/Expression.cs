﻿using Calculator.Interfaces;
using Calculator.Operations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace Calculator;

public class Expression
{
    private readonly List<ITerm> _terms = [];
    private readonly Stack<Expression> _openedExpressions = [];
    private bool _built = false;

    public Expression Add(ITerm term, Expression? parent = null)
    {
        if (_openedExpressions.Count > 0)
        {
            _openedExpressions.Peek().Add(term, this);
        }
        else
        {
            if (term is ITerminalExpression)
            {
                if (parent != null)
                {
                    parent.CloseSubExpression();
                    return parent.Add(term);
                }
                else
                {
                    throw new InvalidOperationException($"Unable to close expression: {term}");
                }
            }
            else
            {
                _terms.Add(term);
                term.Id = Count;
                term.PartOf(this);
            }
        }

        return this;
    }

    public Expression Build()
    {
        if (!_built)
        {
            // start with the operation that has more priority
            foreach (var op in OperationsByPriority)
            {
                op.PrepareForCalculation();
            }

            _built = true;
        }

        return this;
    }

    public decimal Calculate()
    {
        Build();

        if (_terms.Count == 0)
            throw new InvalidOperationException("Unable to calculate an empty expression");

        if (Operations.Count == 0)
        {
            // No operations in expression. Example: "5"
            return _terms.First().Calculate();
        }

        // Go to the operation with the least priority to start the calculation,
        // which is the one that all depends and it depends on no one
        // and go back from there
        return OperationsByPriority.Last().Calculate();
    }

    public virtual Expression OpenSubExpresssion(Operation operation)
    {
        var subExpression = new Expression();
        _openedExpressions.Push(subExpression);
        return subExpression;
    }

    public virtual Expression CloseSubExpression()
    {
        return _openedExpressions.Pop();
    }

    public virtual bool CanCloseSubExpression()
    {
        return _openedExpressions.Count > 0 && _openedExpressions.Peek()._openedExpressions.Count == 0;
    }

    public virtual ITerm? GetLeftOperandOf(Operation operation)
    {
        var left = _terms
            .Where(x => x.Id < operation.Id && x is not ITerminalExpression)
            .OrderByDescending(x => x.Id)
            .FirstOrDefault();

        while (left != null && left.Captured) left = left.BelongsTo;
        return left;
    }

    public virtual ITerm? GetRightOperandOf(Operation operation)
    {
        var right = _terms
            .Where(x => x.Id > operation.Id && x is not ITerminalExpression)
            .OrderBy(x => x.Id)
            .FirstOrDefault();

        while (right != null && right.Captured) right = right.BelongsTo;
        return right;
    }

    public override string? ToString()
    {
        if (Operations.Count == 0 && _terms.Count > 0)
        {
            // No operations in expression. Example: "5"
            return _terms.First().ToString();
        }
        else if (OperationsByPriority != null && OperationsByPriority.Count > 0)
        {
            var lastOp = OperationsByPriority.Last();
            return lastOp == null ? String.Empty : lastOp.ToString();
        }

        return String.Empty;
    }

    /**
     * Properties
     */
    public int Count { get { return _terms.Count; } }
    public IList<Operation> Operations
    {
        get
        {
            return _terms.Where(x => x is Operation).Cast<Operation>()
                .ToList();
        }
    }
    public IList<Operation> OperationsByPriority
    {
        get
        {
            return [.. _terms.Where(x => x is Operation && x is not ITerminalExpression).Cast<Operation>()
                .OrderByDescending(x => x.Priority)
                .ThenBy(x => x.Id)];
        }
    }
}
