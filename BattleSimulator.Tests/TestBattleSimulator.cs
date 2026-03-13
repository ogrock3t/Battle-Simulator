using Itmo.ObjectOrientedProgramming.Lab3.Battle;
using Itmo.ObjectOrientedProgramming.Lab3.Battle.Result;
using Itmo.ObjectOrientedProgramming.Lab3.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Table;
using Itmo.ObjectOrientedProgramming.Lab3.Table.Builders;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class TestBattleSimulator
{
    [Fact]
    public void Attack_Different_BoostMimicChest()
    {
        // Arrange
        ICreature chest = new MimicChestBuilderFactory().CreateBuilder().Build();
        ICreature horror = new ImmortalHorrorBuilderFactory().CreateBuilder().Build();
        int initialAttack = horror.Attack.Value;
        int initialHealth = horror.Health.Value;

        // Act
        chest.AttackCreature(horror);

        // Assert
        Assert.Equal(initialAttack, chest.Attack.Value);
        Assert.Equal(initialHealth, chest.Health.Value);
    }

    [Fact]
    public void Reborn_Alive_ImmortalHorrorReborn()
    {
        // Arrange
        ICreature horror = new ImmortalHorrorBuilderFactory().CreateBuilder().Build();
        int initialHealth = horror.Health.Value;

        // Act
        horror.TakeDamage(initialHealth);

        // Assert
        Assert.Equal(1, horror.Health.Value);
    }

    [Fact]
    public void Attack_Different_BoostBattleAnalyst()
    {
        // Arrange
        ICreature analyst = new BattleAnalystBuilderFactory().CreateBuilder().Build();
        ICreature fighter = new EvilFighterBuilderFactory().CreateBuilder().Build();

        // Assert
        Assert.Equal(2, analyst.Attack.Value);
        Assert.Equal(4, analyst.Health.Value);

        // Act
        analyst.AttackCreature(fighter);

        // Assert
        Assert.Equal(4, analyst.Attack.Value);
        Assert.Equal(4, analyst.Health.Value);
    }

    [Fact]
    public void Clone_Different_FromCatalogPrototype()
    {
        // Arrange
        var catalog = new CreatureCatalog();
        var evilFighterFactory = new EvilFighterBuilderFactory();
        ICreatureBuilder battleAnalyst = evilFighterFactory.CreateBuilder();
        catalog.Add("Analyst", battleAnalyst.Build());
        ICreature fighterOnBoard = catalog.Get("Analyst").Clone();
        PlayerBoard board = new PlayerBoardBuilder().WithCreature(fighterOnBoard).Build();
        ICreature fighterOnCatalog = catalog.Get("Analyst");

        // Act
        var spell = new EndurancePotion();
        fighterOnBoard = spell.Apply(fighterOnBoard);

        // Assert
        Assert.NotEqual(fighterOnCatalog.Health.Value, fighterOnBoard.Health.Value);
    }

    [Fact]
    public void Fight_Win_AnalystVsAnalyst()
    {
        // Arrange
        var catalog = new CreatureCatalog();
        var battleAnalystFactory = new BattleAnalystBuilderFactory();
        ICreatureBuilder battleAnalyst = battleAnalystFactory.CreateBuilder();
        catalog.Add("Analyst", battleAnalyst.Build());
        PlayerBoard firstBoard = new PlayerBoardBuilder().WithCreature(catalog.Get("Analyst").Clone()).Build();
        PlayerBoard secondBoard = new PlayerBoardBuilder().WithCreature(catalog.Get("Analyst").Clone()).Build();
        var battle = new BattleSimulator(firstBoard, secondBoard);

        // Act
        BattleResult result = battle.Fight();

        // Assert
        Assert.IsType<BattleResult.PlayerWin>(result);
    }

    [Fact]
    public void Fight_Draw_AnalystVsAnalyst()
    {
        // Arrange
        var catalog = new CreatureCatalog();
        var battleAnalystFactory = new BattleAnalystBuilderFactory();
        ICreatureBuilder battleAnalyst = battleAnalystFactory.CreateBuilder();
        catalog.Add("Analyst", battleAnalyst.Build());
        PlayerBoard firstBoard = new PlayerBoardBuilder().Build();
        PlayerBoard secondBoard = new PlayerBoardBuilder().Build();
        var battle = new BattleSimulator(firstBoard, secondBoard);

        // Act
        BattleResult result = battle.Fight();

        // Assert
        Assert.IsType<BattleResult.Draw>(result);
    }

    [Fact]
    public void MagicShield_Apply_CreatureWithModifier()
    {
        // Arrange
        ICreature analyst = new BattleAnalystBuilderFactory().CreateBuilder().Build();
        var magicShield = new MagicShieldFactory();
        ICreature analystWithShield = magicShield.CreateModifier(analyst);
        int initialHealth = analystWithShield.Health.Value;
        ICreature chest = new MimicChestBuilderFactory().CreateBuilder().Build();

        // Act
        chest.AttackCreature(analystWithShield);

        // Assert
        Assert.Equal(initialHealth, analystWithShield.Health.Value);
    }

    [Fact]
    public void AttackSkill_Apply_CreatureWithModifier()
    {
        // Arrange
        ICreature fighter = new EvilFighterBuilderFactory().CreateBuilder().Build();
        var attackSkill = new AttackSkillFactory();
        ICreature fighterWithAttackSkill = attackSkill.CreateModifier(fighter);
        ICreature analyst = new BattleAnalystBuilderFactory().CreateBuilder().Build();
        int initialHealth = analyst.Health.Value;
        int expectedDamage = fighter.Attack.Value * 2;

        // Act
        fighterWithAttackSkill.AttackCreature(analyst);

        // Assert
        Assert.Equal(initialHealth - expectedDamage, analyst.Health.Value);
    }

    [Fact]
    public void DoubleMagicShield_Apply_CreatureWithModifier()
    {
        // Arrange
        ICreature analyst = new BattleAnalystBuilderFactory().CreateBuilder().Build();
        var magicShield = new MagicShieldFactory();
        ICreature analystWithShield = magicShield.CreateModifier(magicShield.CreateModifier(analyst));
        int initialHealth = analystWithShield.Health.Value;
        ICreature chest = new MimicChestBuilderFactory().CreateBuilder().Build();

        // Act
        chest.AttackCreature(analystWithShield);
        chest.AttackCreature(analystWithShield);

        // Assert
        Assert.Equal(initialHealth, analystWithShield.Health.Value);
    }

    [Fact]
    public void MagicMirror_Apply_CreatureWithSpell()
    {
        // Arrange
        ICreature analyst = new BattleAnalystBuilderFactory().CreateBuilder().Build();
        int initialAttack = analyst.Attack.Value;
        int initialHealth = analyst.Health.Value;
        var mirror = new MagicMirror();

        // Act
        mirror.Apply(analyst);

        // Assert
        Assert.Equal(initialAttack, analyst.Health.Value);
        Assert.Equal(initialHealth, analyst.Attack.Value);
    }
}