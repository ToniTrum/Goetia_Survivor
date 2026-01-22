using UnityEngine;

public class EnemyHand : Hand<EnemyStateType>
{
    public void Update()
    {
        var direction = GetDirection().Value;
        if (direction == null)
        {
            return;
        }
        direction = direction.normalized;

        if (GetState() == EnemyStateType.Attack)
        {
            if (transform.localScale.x < 0)
            {
                direction.x = -direction.x;
            }
        }
        else
        {
            direction = transform.localScale.x < 0 ? Vector3.left : Vector3.right;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // other.GetComponent<Player>().TakeDamage(Presenter.GetDamage());
            Collider2D.isTrigger = false;
        }
    }
}