using Calculator.Interfaces;
using Calculator.Numbers;
using Calculator.Operations;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Calculator;

public class Interpreter
{
    public class InterpreterContext
    {
        public required char[] Expression { get; set; }
        public int CurrIndex { get; set; } = 0;
    }

    private static readonly Dictionary<string, Type> _supportedOperations = [];
    private static readonly Dictionary<string, Type> _supportedConstants = [];

    static Interpreter()
    {
        BuildLexer();
    }

    public static Expression Interpret(char[] expression)
    {
        var interpreted = new Expression();
        var ctx = new InterpreterContext() { Expression = expression };

        while (ctx.CurrIndex < ctx.Expression.Length)
        {
            var curr = ctx.Expression[ctx.CurrIndex];
            if (curr == ' ')
            {
                ctx.CurrIndex += 1;
                continue; // skip if is a space
            }

            // STEPS
            //  1. Check if is number
            //  2. Check if is operation
            //  3. Check if is constant
            //  4. throw parsing error

            if (Char.IsNumber(curr))
            {
                interpreted.Add(new Number(GetNumber(ctx)));
            }
            else // not a number
            {
                if(_supportedOperations.ContainsKey(curr.ToString()))
                {
                    var op = (Operation?)Activator.CreateInstance(_supportedOperations[curr.ToString()]);
                    if (op == null) throw new ApplicationException($"Something wrong with operation '{curr}' at character {ctx.CurrIndex + 1}");

                    interpreted.Add(op);
                }
                else
                {
                    var text = GetText(ctx);
                    if (_supportedConstants.TryGetValue(text, out Type? value))
                    {
                        var number = (Number?)Activator.CreateInstance(value);
                        if (number == null) throw new ApplicationException($"Something wrong with constant '{text}' at character {ctx.CurrIndex - text.Length + 2}");

                        interpreted.Add(number);
                    }
                    else
                    {
                        throw new ApplicationException($"Unrecognized expression '{text}' at character {ctx.CurrIndex - text.Length + 2}");
                    }
                }
            }
            ctx.CurrIndex += 1;
        }

        return interpreted;
    }

    private static decimal GetNumber(InterpreterContext ctx)
    {
        StringBuilder sb = new();
        var stillNumber = true;

        while(stillNumber)
        {
            if (ctx.CurrIndex == ctx.Expression.Length) break;

            var curr = ctx.Expression[ctx.CurrIndex];
            if (Char.IsNumber(curr) || curr == '.' || curr == ',')
            {
                sb.Append(curr);
                ctx.CurrIndex += 1;
            }
            else
            { 
                stillNumber = false;
                ctx.CurrIndex -= 1;
            }
        }

        // parsing according to the current locale
        // https://learn.microsoft.com/en-us/dotnet/api/system.decimal.tryparse?view=net-9.0
        // https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-globalization-cultureinfo-currentculture
        if (!Decimal.TryParse(sb.ToString(), CultureInfo.CurrentCulture, out decimal result))
        {
            throw new ApplicationException($"Something wrong with number '{sb}' at character {ctx.CurrIndex - sb.Length + 2}");
        }
        return result;
    }

    private static string GetText(InterpreterContext ctx)
    {
        StringBuilder sb = new();
        var stillText = true;

        while (stillText)
        {
            if (ctx.CurrIndex == ctx.Expression.Length) break;

            var curr = ctx.Expression[ctx.CurrIndex];
            if (Char.IsLetter(curr))
            {
                sb.Append(curr);
                ctx.CurrIndex += 1;
            }
            else
            {
                stillText = false;
                ctx.CurrIndex -= 1;
            }
        }

        return sb.ToString();
    }

    private static void BuildLexer()
    {
        BuildOperations();
        BuildConstants();
    }

    private static void BuildConstants()
    {
        foreach (var type in GetAllTypesThatImplement<IConstant>())
        {
            if (Activator.CreateInstance(type) is not IConstant constant) continue;
            _ = _supportedConstants.TryAdd(constant.Symbol, type);
        }
    }

    private static void BuildOperations()
    {
        foreach (var type in GetAllTypesThatImplement<Operation>())
        {
            if (Activator.CreateInstance(type) is not Operation operation) continue;
            _supportedOperations.TryAdd(operation.Symbol, type);
        }
    }
    private static IEnumerable<Type> GetAllTypesThatImplement<T>()
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);
    }
}
