using System.Collections;
using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour
{
    [Inject] protected ProjectilePresenter presenter;
    [Inject] protected ProjectileMovement movement;

    private Coroutine _destroyCoroutine;
    private float _lifetime = 5f;

    private void Start()
    {
        _destroyCoroutine = StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(_lifetime);
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        if (_destroyCoroutine != null)
        {
            StopCoroutine(_destroyCoroutine);
        }
    }

    void Update()
    {
        movement.Move(presenter.GetSpeed(), transform);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // collision.GetComponent<Player>().TakeDamage(presenter.GetDamage());
            Destroy(gameObject);
        }
    }
}
