namespace Calculator;

public abstract class Term : ITerm
{
    /**
     * Methods
     */
    public abstract decimal Calculate();
    public virtual void PartOf(Expression expression)
    {
        ArgumentNullException.ThrowIfNull(expression);

        ParentExpression = expression;
    }
    public virtual void PartOf(ITerm term)
    {
        ArgumentNullException.ThrowIfNull(term);

        Captured = true;
        BelongsTo = term;
    }
    public abstract override string? ToString();

    /**
     * Properties
     */
    public int Id { get; set; }
    public ITerm? BelongsTo { get; protected set; } = null;
    public bool Captured { get; protected set; } = false;
    public Expression? ParentExpression { get; set; } = null;
}
