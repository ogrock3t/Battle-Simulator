using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public abstract class BaseCreature : ICreature
{
    protected BaseCreature(Attack attack, Health health)
    {
        Attack = attack;
        Health = health;
    }

    public Attack Attack { get; protected set; }

    public Health Health { get; protected set; }

    public virtual void AttackCreature(ICreature opponent)
    {
        opponent.TakeDamage(Attack.Value);
    }

    public virtual void TakeDamage(int damage)
    {
        Health = new Health(Health.Value - damage);

        if (Health.Value < 0)
            Health = new Health(0);
    }

    public void ChangeAttack(Attack attack)
    {
        Attack = attack;
    }

    public void ChangeHealth(Health health)
    {
        Health = health;
    }

    public abstract ICreature Clone();
}