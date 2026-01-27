using Unity.VisualScripting;
using Zenject;

public class ProjectilePresenter
{
    [Inject] protected ProjectileModel Model { get; private set; }

    public float GetSpeed()
    {
        return Model.Speed;
    }

    public int GetDamage()
    {
        return Model.Damage;
    }
}
