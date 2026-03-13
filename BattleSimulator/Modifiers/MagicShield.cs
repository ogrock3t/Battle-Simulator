using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class MagicShield : ICreature
{
    private readonly ICreature _creature;

    private bool _usedShield;

    public MagicShield(ICreature creature, bool usedShield = false)
    {
        _creature = creature;
        _usedShield = usedShield;
    }

    public Attack Attack => _creature.Attack;

    public Health Health => _creature.Health;

    public void AttackCreature(ICreature opponent)
    {
        _creature.AttackCreature(opponent);
    }

    public void TakeDamage(int damage)
    {
        if (_usedShield)
            _creature.TakeDamage(damage);
        else
            _usedShield = true;
    }

    public void ChangeAttack(Attack attack)
    {
        _creature.ChangeAttack(attack);
    }

    public void ChangeHealth(Health health)
    {
        _creature.ChangeHealth(health);
    }

    public ICreature Clone()
    {
        return new MagicShield(_creature, _usedShield);
    }
}