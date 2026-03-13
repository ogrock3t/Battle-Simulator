using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class BattleAnalyst : BaseCreature
{
    private bool _boosted;

    public BattleAnalyst(Attack attack, Health health, bool boosted = false)
        : base(attack, health)
    {
        _boosted = boosted;
    }

    public override void AttackCreature(ICreature opponent)
    {
        if (!_boosted)
        {
            Attack = new Attack(Attack.Value + 2);
            _boosted = true;
        }

        opponent.TakeDamage(Attack.Value);
    }

    public override ICreature Clone()
    {
        return new BattleAnalyst(Attack, Health, _boosted);
    }
}