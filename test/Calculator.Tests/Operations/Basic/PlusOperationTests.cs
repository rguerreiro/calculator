namespace Calculator.Tests.Operations.Basic;

[TestFixture]
public class PlusOperationTests
{
    private Expression _expression;

    [SetUp]
    public void Setup()
    {
        _expression = new Expression();
    }

    [Test]
    public void PlusOperation_AddTwoNumbers_Equal()
    {
        decimal expected = 1 + 1;
        var result = _expression
            .Add(new Number(1))
            .Add(new PlusOperation())
            .Add(new Number(1))
            .Calculate();

        Assert.That(result, Is.EqualTo(expected));
    }
}