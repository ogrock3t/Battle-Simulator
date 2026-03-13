using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class AttackSkill : ICreature
{
    private readonly ICreature _creature;

    private bool _usedAttack;

    public AttackSkill(ICreature creature, bool usedAttack = false)
    {
        _creature = creature;
        _usedAttack = usedAttack;
    }

    public Attack Attack => _creature.Attack;

    public Health Health => _creature.Health;

    public void AttackCreature(ICreature opponent)
    {
        _creature.AttackCreature(opponent);

        if (_usedAttack)
            return;

        _creature.AttackCreature(opponent);
        _usedAttack = true;
    }

    public void TakeDamage(int damage)
    {
        _creature.TakeDamage(damage);
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
        return new AttackSkill(_creature, _usedAttack);
    }
}