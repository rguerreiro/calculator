namespace Calculator;

public abstract class Term(int priority = 0) : ITerm
{
    /**
     * Methods
     */
    public abstract decimal Calc();
    public virtual void PartOf(ITerm term)
    {
        ArgumentNullException.ThrowIfNull(term);

        Captured = true;
        BelongsTo = term;
    }

    /**
     * Properties
     */
    public int Id { get; set; }
    public int Priority { get; private set; } = priority;
    public ITerm? BelongsTo { get; protected set; } = null;
    public bool Captured { get; protected set; } = false;
}
