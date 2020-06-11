using UnityEngine;
using Zenject;

public class AIE_InputSystemInstaller : MonoInstaller
{
	//Player Prefab
	public GameObject m_prefabControl, m_prefabXRControl;

	public override void InstallBindings()
    {
		//Binding the input class to its interfaces and registering to the conatainer
		Container.BindInterfacesAndSelfTo<InputController>().AsSingle();

		//Binding the DeviceDetectionSystem class to its interfaces and registering to the conatainer
		Container.BindInterfacesTo<DeviceDetectionSystem>().AsSingle();

		//Every gameobject instantiated through the container is registered to the container and injection can be done
		Container.BindMemoryPool<UserControls, UserControls.UserControlPool>().WithId("DefaultControl").WithInitialSize(1).FromComponentInNewPrefab(m_prefabControl).UnderTransformGroup("USER");
		Container.BindMemoryPool<UserControls, UserControls.UserControlPool>().WithId("XRControl").WithInitialSize(1).FromComponentInNewPrefab(m_prefabXRControl).UnderTransformGroup("USER_XR");
	}
}