using Calculator;
using Calculator.Operations;
using Calculator.Operations.Basic;
using Calculator.Numbers;
using Calculator.Operations.Notation;

//var expression = new Expression();

// 1 + 3 - 2 / 5 * 7 = 1.2
//expression
//    .Add(new Number(1))
//    .Add(new PlusOperation())
//    .Add(new Number(3))
//    .Add(new MinusOperation())
//    .Add(new Number(2))
//    .Add(new DivideOperation())
//    .Add(new Number(5))
//    .Add(new MultiplyOperation())
//    .Add(new Number(7));

// 1 + (3 - 2) / 5 * 7 = 2.4
//expression
//    .Add(new Number(1))
//    .Add(new PlusOperation())
//    .Add(new OpenBracket())
//    .Add(new Number(3))
//    .Add(new MinusOperation())
//    .Add(new Number(2))
//    .Add(new CloseBracket())
//    .Add(new DivideOperation())
//    .Add(new Number(5))
//    .Add(new MultiplyOperation())
//    .Add(new Number(7));

// (1 + 3) = 4
//expression
//    .Add(new OpenBracket())
//    .Add(new Number(1))
//    .Add(new PlusOperation())
//    .Add(new Number(3))
//    .Add(new CloseBracket());

// pi ^ (1 + 1) - 1 = 8.8696044...
//expression
//    .Add(new Pi())
//    .Add(new PowerOperation())
//    .Add(new OpenBracket())
//    .Add(new Number(1))
//    .Add(new PlusOperation())
//    .Add(new Number(1))
//    .Add(new CloseBracket())
//    .Add(new MinusOperation())
//    .Add(new Number(1));

//var expression = Interpreter.Interpret("1 + 3 - 2 / 5 * 7".ToCharArray());
var expression = Interpreter.Interpret("pi ^ (1 + 1) - 1".ToCharArray());

var result = expression.Calculate();

Console.WriteLine($"{expression} = {result}");