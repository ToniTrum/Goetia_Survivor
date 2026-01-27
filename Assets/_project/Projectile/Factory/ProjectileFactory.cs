using Zenject;
using UnityEngine;

public class ProjectileFactory
{
    private readonly DiContainer _container;
    
    public ProjectileFactory(DiContainer container)
    {
        _container = container;
    }
    
    public Projectile Create
    (
        ProjectileConfig projectileConfig, 
        Vector3 position,
        Quaternion direction
    )
    {
        var subContainer = _container.CreateSubContainer();

        subContainer.Bind<ProjectileModel>()
            .AsTransient()
            .WithArguments(projectileConfig);

        subContainer.Bind<ProjectilePresenter>()
            .AsTransient();

        subContainer.Bind<ProjectileMovement>()
            .AsTransient();
            
        subContainer.Bind<ProjectileView>()
            .AsTransient();
        
        return subContainer.InstantiatePrefabForComponent<Projectile>(
            projectileConfig.Prefab,
            position,
            direction,
            null
        );
    }
}