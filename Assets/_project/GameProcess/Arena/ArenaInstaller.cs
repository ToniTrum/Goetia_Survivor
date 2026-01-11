using Zenject;
using UnityEngine;

public class ArenaInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EnemyService>()
            .AsSingle();

        Container.BindFactory<Vector3, GameObject, Enemy, Enemy.Factory>();
    }
}