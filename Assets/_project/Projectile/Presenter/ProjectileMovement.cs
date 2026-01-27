using UnityEngine;

public class ProjectileMovement
{
    public void Move(float speed, Transform transform)
    {
        transform.position += speed * Time.deltaTime * transform.right;
    }
}