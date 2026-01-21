using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfig playerConfig;
    public float speed = 5.0f;
    public override void InstallBindings()
    {
        Container.Bind<Entity<PlayerStateType>>().
            To<Player>()
            .FromComponentInHierarchy()
            .AsSingle();
        Container.Bind<IEntityView<PlayerStateType>>()
            .To<PlayerView>()   
            .AsSingle();

        Container.Bind<PlayerModel>()
            .FromInstance(
                new PlayerModel(
                    playerConfig.MaxHealth,
                    playerConfig.Speed,
                    playerConfig.DashSpeed,
                    playerConfig.DashDuration,
                    playerConfig.DashCooldown,
                    playerConfig.Gold
                )
            )
            .AsSingle();
        
        Container.Bind<IEntityPresenter>()
            .To<PlayerPresenter>()
            .AsSingle();

        Container.Bind<PlayerFsm>()
            .AsSingle();
    }
}