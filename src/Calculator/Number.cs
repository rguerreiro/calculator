namespace Calculator;

public class Number : ITerm
{
    protected decimal _value;

    public Number(decimal value)
    {
        _value = value;    
    }

    public decimal Calc()
    {
        return _value;
    }
}