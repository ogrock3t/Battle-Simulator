using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

public class AttackSkillFactory : IModifierFactory
{
    public ICreature CreateModifier(ICreature creature)
    {
        return new AttackSkill(creature);
    }
}