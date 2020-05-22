using UnityEngine;
using Zenject;

public class GameSetupInstaller : MonoInstaller
{
	public GameObject m_prefabControl;

	public override void InstallBindings()
    {
		Container.BindInterfacesAndSelfTo<InputController>().AsSingle();
		Container.BindMemoryPool<UserControls, UserControls.UserControlPool>().WithInitialSize(2).FromComponentInNewPrefab(m_prefabControl).UnderTransformGroup("USER");
	}
}