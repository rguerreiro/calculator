using Calculator;
using Calculator.Operations;

// 10 - (-2) - 4 = 10 + 2 - 4 = 8
//var operation = new MinusOperation(new Number(10), new MinusOperation(new Number(-2), new Number(4))); // WRONG SEQUENCE, equals to 16
//var operation = new MinusOperation(new MinusOperation(new Number(10), new Number(-2)), new Number(4));
var operation = new MinusOperation(new PlusOperation(new Number(10), new Number(2)), new Number(4));
var result = operation.Calc();
Console.WriteLine($"Result: {result}");