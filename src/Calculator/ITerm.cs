namespace Calculator;

public interface ITerm
{
    /**
     * Methods
     */
    decimal Calculate();
    void PartOf(ITerm term);

    /**
     * Properties
     */
    int Id { get; set; }
    bool Captured { get; }
    ITerm? BelongsTo { get; }
}
