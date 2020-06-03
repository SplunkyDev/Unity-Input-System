using UnityEngine;
using Zenject;

public class InitilizeInstaller : MonoInstaller
{


	public override void InstallBindings()
    {
		Container.BindInterfacesTo<GameStateHandler>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesTo<SceneHandler>().FromComponentInHierarchy().AsSingle();
    }
}