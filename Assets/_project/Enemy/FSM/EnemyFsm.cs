using UnityEngine;

public class EnemyFsm : EntityFsm<EnemyStateType>
{
    public EnemyFsm()
    {
        _currentState = EnemyStateType.Idle;
    }
}
