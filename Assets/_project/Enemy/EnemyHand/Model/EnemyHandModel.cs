using System.Collections.Generic;
using UnityEngine;
using Zenject;

class EnemyHandModel : HandModel
{
    public EnemyHandModel(HandConfig handBaseModel) : base(handBaseModel) { }

    public override IReadOnlyList<Transform> GetTargets()
    {
        return GameObject.FindWithTag("Player").GetComponentsInChildren<Transform>();
    }
}