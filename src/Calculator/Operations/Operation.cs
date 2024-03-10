﻿using Calculator.Interfaces;

namespace Calculator.Operations;

public abstract class Operation(string symbol, int priority = 1) : Term
{
    /**
     * Methods
     */
    protected virtual ITerm? GetLeftOperand()
    {
        ArgumentNullException.ThrowIfNull(ParentExpression);

        var leftOperand = ParentExpression.GetLeftOperandOf(this);

        ArgumentNullException.ThrowIfNull(leftOperand);

        leftOperand.PartOf(this);

        return leftOperand;
    }

    protected virtual ITerm? GetRightOperand()
    {
        ArgumentNullException.ThrowIfNull(ParentExpression);

        var rightOperand = ParentExpression.GetRightOperandOf(this);

        if(rightOperand == null) throw new InvalidOperationException();

        rightOperand.PartOf(this);

        return rightOperand;
    }

    public virtual void PrepareForCalculation()
    {
    }

    /**
     * Properties
     */
    public string Symbol { get; private set; } = symbol;

    public int Priority { get; private set; } = priority;
}