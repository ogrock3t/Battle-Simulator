using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public class BattleAnalystBuilder : BaseCreatureBuilder
{
    private bool _boosted = false;

    public BattleAnalystBuilder WithBoosted(bool value)
    {
        _boosted = value;
        return this;
    }

    public override ICreature Create(Attack attack, Health health)
    {
        return new BattleAnalyst(attack, health, _boosted);
    }
}