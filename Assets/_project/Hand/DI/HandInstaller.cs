using Zenject;

public class HandInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<HandPresenter>()
            .AsTransient();

        Container.Bind<HandTargetLocator>()
            .AsTransient();
        
        Container.Bind<HandView>()
            .AsTransient();
    }
}