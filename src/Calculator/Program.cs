using Calculator;
using Calculator.Operations;
using Calculator.Operations.Basic;
using Calculator.Numbers;

// 1 + 3 - 2 / 5 * 7 = 1.2
var expression = new Expression();
expression
    .Add(new Number(1))
    .Add(new PlusOperation())
    .Add(new Number(3))
    .Add(new MinusOperation())
    .Add(new Number(2))
    .Add(new DivideOperation())
    .Add(new Number(5))
    .Add(new MultiplyOperation())
    .Add(new Number(7));

var result = expression.Calculate();

Console.WriteLine($"Result: {result}");