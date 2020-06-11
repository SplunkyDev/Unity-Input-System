using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class DeviceDetectionSystem : IDeviceTypeDetected, IInitializable
{
	public InputDevice[] InputDevicesDetected { get; private set; }
	public Utility.Controls.ePreferredControl m_enumPreferredControls;

	

	[Inject(Id = "DefaultControl")]
	private UserControls.UserControlPool m_refDefaultControlPool;
	private List<UserControls> m_lstDefaultControls = new List<UserControls>();
	
	[Inject(Id = "XRControl")]
	private UserControls.UserControlPool m_refXRControlPool;
	private List<UserControls> m_lstXRControls = new List<UserControls>();

	

	public void DeviceDetected(InputDevice a_inputDevice, InputDeviceChange a_inputDeviceChange)
	{
		switch (a_inputDeviceChange)
		{
			case InputDeviceChange.Added:
				break;
			case InputDeviceChange.Removed:
				break;
			case InputDeviceChange.Disconnected:
				break;
			case InputDeviceChange.Reconnected:
				break;
			case InputDeviceChange.Enabled:
				break;
			case InputDeviceChange.Disabled:
				break;
			case InputDeviceChange.UsageChanged:
				break;
			case InputDeviceChange.ConfigurationChanged:
				break;
			case InputDeviceChange.Destroyed:
				break;
		}

		InputDevicesDetected = null;
		InputDevicesDetected = new InputDevice[InputSystem.devices.ToArray().Length];
		InputDevicesDetected = InputSystem.devices.ToArray();


		DevicesUpdated();

		InitializePlayer();
	}


	private void DevicesUpdated()
	{
		Debug.Log("<color=green>*********************************************************</color>");
		for (int i = 0; i < InputDevicesDetected.Length; i++)
		{
			if (InputDevicesDetected[i].device.ToString().Contains("XRInput"))
			{
				m_enumPreferredControls = Utility.Controls.ePreferredControl.XRController;
			}

			Debug.Log("Device detected: " + InputDevicesDetected[i].device);
			Debug.Log("DeviceID: " + InputDevicesDetected[i].deviceId);
			Debug.Log("Device displayName: " + InputDevicesDetected[i].device.displayName);
			Debug.Log("Device description: " + InputDevicesDetected[i].device.description);
			Debug.Log("<color=green>*********************************************************</color>");
		}
	}

	private void InitializePlayer()
	{
		if(m_enumPreferredControls == Utility.Controls.ePreferredControl.XRController)
		{
			if (m_lstXRControls.Count > 0)
				return;

			if(m_lstDefaultControls.Count>0)
			{
				for(int i =0; i< m_lstDefaultControls.Count;i++)
				{
					UserControls refUserControls = m_lstDefaultControls[i];
					m_refDefaultControlPool.Despawn(refUserControls);
					m_lstDefaultControls.Remove(refUserControls);
				}
			}
			UserControls UserControls = m_refXRControlPool.Spawn(Vector3.zero);
			m_lstXRControls.Add(UserControls);

		}
		else
		{
			if (m_lstDefaultControls.Count > 0)
				return;

			if (m_lstXRControls.Count > 0)
			{
				for (int i = 0; i < m_lstXRControls.Count; i++)
				{
					UserControls refUserControls = m_lstXRControls[i];
					m_refXRControlPool.Despawn(refUserControls);
					m_lstXRControls.Remove(refUserControls);
				}
			}

			UserControls UserControls =  m_refDefaultControlPool.Spawn(Vector3.zero);
			m_lstDefaultControls.Add(UserControls);

		}


	}

	public void Initialize()
	{

		m_enumPreferredControls = Utility.Controls.ePreferredControl.XRController;

		Debug.Log("[DeviceDetectionSystem] Initialize");
		InputSystem.onDeviceChange += DeviceDetected;

		InputDevicesDetected = new InputDevice[InputSystem.devices.ToArray().Length];
		InputDevicesDetected = InputSystem.devices.ToArray();


		InitializePlayer();
	}
}
