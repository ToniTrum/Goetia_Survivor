using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerHandModel : HandModel
{
    public PlayerHandModel(HandConfig handConfig) : base(handConfig) {}

    public override IReadOnlyList<Transform> GetTargets()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies == null || enemies.Length == 0)
            return System.Array.Empty<Transform>();

        return enemies.Select(e => e.transform).ToArray();
    }
}