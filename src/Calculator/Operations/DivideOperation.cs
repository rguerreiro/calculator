﻿namespace Calculator.Operations;

public class DivideOperation : Operation
{
    public DivideOperation()
        : base("/", priority: 2)
    {
    }

    public override decimal Calc()
    {
        ArgumentNullException.ThrowIfNull(LeftOperand);
        ArgumentNullException.ThrowIfNull(RightOperand);

        return LeftOperand.Calc() / RightOperand.Calc();
    }
}