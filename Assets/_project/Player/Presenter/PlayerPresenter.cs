using ModestTree;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Video;
using Zenject;

public class PlayerPresenter : IEntityPresenter
{
    [Inject] private PlayerModel _model;
    
    public void DealDamage(IEntity entity, int damage)
    {
        entity.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        _model.TakeDamage(damage);
    }

    public int GetMaxHealth()
    {
        return _model.MaxHealth;
    }

    public int GetHealth()
    {
        return _model.Health;
    }

    public void ApplyItem(Item item)
    {
        item.Apply(_model);
    }
    
}