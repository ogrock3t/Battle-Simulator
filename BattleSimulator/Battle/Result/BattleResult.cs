namespace Itmo.ObjectOrientedProgramming.Lab3.Battle.Result;

public abstract record BattleResult
{
    private BattleResult() { }

    public sealed record PlayerWin() : BattleResult;

    public sealed record EnemyWin() : BattleResult;

    public sealed record Draw() : BattleResult;
}