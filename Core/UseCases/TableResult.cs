namespace UseCases;

public abstract record class TableResult
{
    private TableResult() { }

    public sealed record class EntitiesLimitError() : TableResult;

    public sealed record class Success() : TableResult;
}