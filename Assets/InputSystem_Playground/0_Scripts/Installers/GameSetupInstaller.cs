using UnityEngine;
using Zenject;

public class GameSetupInstaller : MonoInstaller
{
	//Player Prefab
	public GameObject m_prefabControl;

	public override void InstallBindings()
    {
		//Binding the input class to its interfaces and registering to the conatainer
		Container.BindInterfacesAndSelfTo<InputController>().AsSingle();

		//Binding the DeviceDetectionSystem class to its interfaces and registering to the conatainer
		Container.BindInterfacesAndSelfTo<DeviceDetectionSystem>().AsSingle();

		//Every gameobject instantiated through the container is registered to the container and injection can be done
		Container.BindMemoryPool<UserControls, UserControls.UserControlPool>().WithInitialSize(1).FromComponentInNewPrefab(m_prefabControl).UnderTransformGroup("USER");
	}
}