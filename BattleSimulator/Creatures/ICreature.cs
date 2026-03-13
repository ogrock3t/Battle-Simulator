using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature
{
    Attack Attack { get; }

    Health Health { get; }

    void AttackCreature(ICreature opponent);

    void TakeDamage(int damage);

    void ChangeAttack(Attack attack);

    void ChangeHealth(Health health);

    ICreature Clone();
}