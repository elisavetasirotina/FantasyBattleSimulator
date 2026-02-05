using Table;

namespace UseCases;

public abstract record class BattleResult
{
    private BattleResult() { }

    public sealed record class Win(IPlayerTable Table) : BattleResult;

    public sealed record class Draw() : BattleResult;
}