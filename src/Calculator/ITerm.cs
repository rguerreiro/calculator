namespace Calculator;

public interface ITerm
{
    /**
     * Methods
     */
    decimal Calculate();
    void PartOf(ITerm term);
    void PartOf(Expression expression);
    string? ToString();

    /**
     * Properties
     */
    int Id { get; set; }
    bool Captured { get; }
    ITerm? BelongsTo { get; }
    Expression? ParentExpression { get; }
}
