using Bug.BugConfig;
using Bug.Factory;
using Bug.Factory.Interface;
using Bug.Pool;
using Bug.View;
using Eat.Factory;
using Eat.Factory.Interface;
using Eat.Pool;
using Eat.View;
using Manager;
using UI;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Hud hudPrefab;
    
    [SerializeField] private BugConfig workerConfig;
    //[SerializeField] private BugConfig predatorConfig;
    [SerializeField] private BugView bugPrefab;
    [SerializeField] private EatView eatPrefab;
    
    public override void InstallBindings()
    {
        Container.BindInstance(bugPrefab);
        Container.BindInstance(eatPrefab);
                
        Container.BindInstance(workerConfig).WhenInjectedInto<BugFactory>();
        //Container.BindInstance(predatorConfig).WhenInjectedInto<BugFactory>();

        Container.Bind<Stats.Stats>().AsSingle();
        Container.Bind<LifetimeSystem>().AsSingle();
        Container.Bind<IBugFactory>().To<BugFactory>().AsSingle();
        Container.Bind<IEatFactory>().To<EatFactory>().AsSingle();
        Container.Bind<BugPool>().AsSingle();
        Container.Bind<EatPool>().AsSingle();
        Container.Bind<EatRegistry>().AsSingle();

        Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
        Container.BindInterfacesAndSelfTo<EatSpawner>().AsSingle();

        Container.Bind<Hud>()
            .FromComponentInNewPrefab(hudPrefab)
            .UnderTransform(canvas.transform)
            .AsSingle()
            .NonLazy();
    }
}