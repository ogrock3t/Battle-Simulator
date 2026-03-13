using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public class ImmortalHorrorBuilder : BaseCreatureBuilder
{
    private bool _reborn = false;

    public ImmortalHorrorBuilder WithReborn(bool value)
    {
        _reborn = value;
        return this;
    }

    public override ICreature Create(Attack attack, Health health)
    {
        return new ImmortalHorror(attack, health, _reborn);
    }
}