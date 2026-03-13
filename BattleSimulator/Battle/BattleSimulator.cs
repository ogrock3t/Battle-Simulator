using Itmo.ObjectOrientedProgramming.Lab3.Battle.Result;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Table;

namespace Itmo.ObjectOrientedProgramming.Lab3.Battle;

public class BattleSimulator
{
    private readonly PlayerBoard _firstBoard;
    private readonly PlayerBoard _secondBoard;

    public BattleSimulator(PlayerBoard firstBoard, PlayerBoard secondBoard)
    {
        _firstBoard = firstBoard.Clone();
        _secondBoard = secondBoard.Clone();
    }

    public BattleResult Fight()
    {
        bool firstTurn = true;

        while (true)
        {
            if (_firstBoard == null || _secondBoard == null)
                throw new InvalidOperationException("First board and second board must be set before fighting.");

            PlayerBoard attackerBoard = firstTurn ? _firstBoard : _secondBoard;
            PlayerBoard defenderBoard = firstTurn ? _secondBoard : _firstBoard;

            ICreature? attacker = attackerBoard.FindAttacker();
            ICreature? defender = defenderBoard.FindDefender();

            BattleResult? tempResult = CheckCorrectBattle(attacker, defender);

            if (tempResult is not null)
                return tempResult;

            if (attacker is not null && defender is not null)
                attacker.AttackCreature(defender);

            firstTurn = !firstTurn;
        }
    }

    private BattleResult? CheckCorrectBattle(ICreature? attacker, ICreature? defender)
    {
        if (attacker is null)
        {
            return defender is null ?
                new BattleResult.Draw() : new BattleResult.PlayerWin();
        }

        return defender is null ? new BattleResult.Draw() : null;
    }
}