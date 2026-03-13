using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public class BattleAnalystBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder CreateBuilder()
    {
        var builder = new BattleAnalystBuilder();

        builder.WithAttack(2).WithHealth(4);
        builder.WithBoosted(false);

        return builder;
    }
}