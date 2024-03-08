namespace Calculator;

public interface ITerm
{
    /**
     * Methods
     */
    decimal Calc();
    void PartOf(ITerm term);

    /**
     * Properties
     */
    int Id { get; set; }
    int Priority { get; }
    bool Captured { get; }
    ITerm? BelongsTo { get; }
}
