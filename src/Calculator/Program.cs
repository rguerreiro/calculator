using Calculator;
using Calculator.Operations;

// 1 + 3 - 2 / 5 * 7 = 1.2
Expression exp = new();
exp.AddTerm(new Number(1));
exp.AddTerm(new PlusOperation());
exp.AddTerm(new Number(3));
exp.AddTerm(new MinusOperation());
exp.AddTerm(new Number(2));
exp.AddTerm(new DivideOperation());
exp.AddTerm(new Number(5));
exp.AddTerm(new MultiplyOperation());
exp.AddTerm(new Number(7));

var result = exp.Calc();
Console.WriteLine($"Result: {result}");