using UnityEngine;

public class EnemyMovement
{
    public bool IsMoving { get; private set; } = false;

    public void Move(Vector3 targetPosition, Transform transform, float range, float speed)
    {
        if (Vector3.Distance(transform.position, targetPosition) > range)
        {
            IsMoving = true;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            IsMoving = false;
        }
    }
}