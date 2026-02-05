using Entities;
using Table;
using UseCases;

namespace Battle;

public class BattleFacade
{
    private static readonly Lazy<BattleFacade> _battle = new Lazy<BattleFacade>(() => new BattleFacade());

    private int _count = 0;

    private BattleFacade() { }

    public static BattleFacade Create => _battle.Value;

    public BattleResult PlayersBattle(IPlayerTable playerTable1, IPlayerTable playerTable2)
    {
        IEntity? attackEntity;
        IEntity? acceptEntity;
        _count++;
        if (_count % 2 == 1)
        {
            attackEntity = playerTable1.FindAttackEntity();
            acceptEntity = playerTable2.FindAcceptEntity();
        }
        else
        {
            attackEntity = playerTable2.FindAttackEntity();
            acceptEntity = playerTable1.FindAcceptEntity();
        }

        if (attackEntity != null && acceptEntity != null)
        {
            attackEntity.Attack(acceptEntity);
            return PlayersBattle(playerTable1, playerTable2);
        }
        else if (attackEntity == null && acceptEntity != null)
        {
            return PlayersBattle(playerTable1, playerTable2);
        }
        else if (attackEntity != null && acceptEntity == null)
        {
            return new BattleResult.Win(_count % 2 == 1 ? playerTable1 : playerTable2);
        }
        else
        {
            return new BattleResult.Draw();
        }
    }
}