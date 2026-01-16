using System.Collections.Generic;
using UnityEngine;

public class HandPresenter
{
    readonly HandModel _model;

    public IReadOnlyList<Transform> GetTargets()
    {
        return _model.GetTargets();
    }
}
