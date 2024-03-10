namespace Calculator;

public abstract class Term : ITerm
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
    public ITerm? BelongsTo { get; protected set; } = null;
    public bool Captured { get; protected set; } = false;
}
