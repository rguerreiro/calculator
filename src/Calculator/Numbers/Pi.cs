using Calculator.Interfaces;

namespace Calculator.Numbers;

public class Pi : Number, IConstant
{
    public Pi()
        :base(Math.PI)
    {
    }

    public override string ToString()
    {
        return "pi";
    }
}
