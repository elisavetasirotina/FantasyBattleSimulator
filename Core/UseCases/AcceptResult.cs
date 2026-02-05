namespace UseCases;

public abstract record class AcceptResult
{
    private AcceptResult() { }

    public sealed record class Success() : AcceptResult;

    public sealed record class Failure() : AcceptResult;
}