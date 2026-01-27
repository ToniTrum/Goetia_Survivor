using System;

public class EnemyHandAttackProvider
{
    public Type GetEnemyHandAttack(EnemyType enemyType)
    {
        return enemyType switch
        {
            EnemyType.Furcas => typeof(FurcasHandAttack),
            EnemyType.Leraie => typeof(LeraieHandAttack),
            _ => throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null),
        };
    }
}