using UnityEngine;

public class EnemyMovement
{
    private readonly float _verticalTolerance = 0.25f;

    public bool IsMoving { get; private set; } = false;

    public void Move(Vector3 targetPosition, Transform transform, float range, float speed)
    {
        float distance = Vector3.Distance(transform.position, targetPosition);
        float verticalDifference = Mathf.Abs((targetPosition - transform.position).y);
        
        if (distance > range)
        {
            IsMoving = true;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else if (verticalDifference > _verticalTolerance)
        {
            IsMoving = true;
            Vector3 moveDirection = new(0f, Mathf.Sign((targetPosition - transform.position).y), 0f);
            transform.position += speed * Time.deltaTime * moveDirection;
        }
        else
        {
            IsMoving = false;
        }
    }
}