using System.Collections.Generic;
using UnityEngine;

public abstract class HandModel
{
    public float Range { get; private set; }
    public float AttackCooldown { get; private set; }
    public int Damage { get; private set; }

    public HandModel(HandConfig handBaseModel)
    {
        Range = handBaseModel.BaseRange;
        AttackCooldown = handBaseModel.BaseAttackCooldown;
        Damage = handBaseModel.BaseDamage;
    }

    public abstract IReadOnlyList<Transform> GetTargets();
}