using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public class ImmortalHorrorBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder CreateBuilder()
    {
        var builder = new ImmortalHorrorBuilder();

        builder.WithAttack(4).WithHealth(4);
        builder.WithReborn(false);

        return builder;
    }
}