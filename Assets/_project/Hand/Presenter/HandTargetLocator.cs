using UnityEngine;
using System.Collections.Generic;

public class HandTargetLocator
{
    public Transform ChooseTarget(IReadOnlyList<Transform> targets, Vector3 position)
    {
        float minDistance = float.MaxValue;
        Transform nearestTarget = null;

        for (int i = 0; i < targets.Count; i++)
        {
            Transform target = targets[i];
            float distance = Vector3.Distance(target.position, position);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestTarget = target;
            }
        }

        return nearestTarget;
    }

    public Vector2 TargetDirection(Transform target, Vector3 position)
    {
        return (target.position - position).normalized;
    }
}
