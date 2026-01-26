using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HandPresenter
{
    [Inject] protected HandModel Model { get; private set; }

    public IReadOnlyList<Transform> GetTargets()
    {
        return Model.GetTargets();
    }

    public int GetDamage()
    {
        return Model.Damage;
    }

    public float GetRange()
    {
        return Model.Range;
    }
}
