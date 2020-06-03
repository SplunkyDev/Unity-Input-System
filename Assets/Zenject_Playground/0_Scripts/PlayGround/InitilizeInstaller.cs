using UnityEngine;
using Zenject;

public class InitilizeInstaller : MonoInstaller
{


	public override void InstallBindings()
    {
		Container.BindInterfacesTo<GameStateHandler>().AsSingle();
		Container.BindInterfacesTo<SceneHandler>().AsSingle();
    }
}