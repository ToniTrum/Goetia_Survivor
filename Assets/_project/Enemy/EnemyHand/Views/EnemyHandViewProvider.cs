using System;

public class EnemyHandViewProvider
{
    public Type GetEnemyHandType(EnemyType enemyType)
    {
        return enemyType switch
        {
            EnemyType.Furcas => typeof(FurcasHandView),
            _ => throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null),
        };
    }
}