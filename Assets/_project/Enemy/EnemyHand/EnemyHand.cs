using UnityEngine;

public class EnemyHand : Hand<EnemyStateType>
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //other.GetComponent<Player>().TakeDamage(Presenter.GetDamage());
            Collider2D.isTrigger = false;
        }
    }
}