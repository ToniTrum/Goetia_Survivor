using System.Collections.Generic;
using UnityEngine;
using Zenject;

class EnemyHandModel : HandModel
{
    [Inject] private PlayerView player;

    public EnemyHandModel(HandBaseModel handBaseModel) : base(handBaseModel) { }

    public override IReadOnlyList<Transform> GetTargets()
    {
        return (IReadOnlyList<Transform>)player.transform;
    }
}