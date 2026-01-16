using System.Collections.Generic;
using UnityEngine;

public abstract class HandModel
{
    public float Range { get; private set; }
    public float AttackCooldown { get; private set; }
    public float Damage { get; private set; }

    public HandModel(HandBaseModel handBaseModel)
    {
        Range = handBaseModel.BaseRange;
        AttackCooldown = handBaseModel.BaseAttackCooldown;
        Damage = handBaseModel.BaseDamage;
    }

    public virtual IReadOnlyList<Transform> GetTargets()
    {
        return null;
    }
}