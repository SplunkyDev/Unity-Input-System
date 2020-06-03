using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class DeviceDetectionSystem : IDeviceTypeDetected, IInitializable
{
	public InputDevice[] InputDevicesDetected { get; private set; }
	public Utility.Controls.ePreferredControl m_enumPreferredControls;

	private UserControls.UserControlPool m_refControlPool;
	private List<UserControls> m_lstInputControls = new List<UserControls>();

	[Inject]
	private DeviceDetectionSystem(UserControls.UserControlPool a_refControlPool)
	{
		m_refControlPool = a_refControlPool;
	}


	public void DeviceDetected(InputDevice a_inputDevice, InputDeviceChange a_inputDeviceChange)
	{
		switch (a_inputDeviceChange)
		{
			case InputDeviceChange.Added:
				Debug.Log(a_inputDevice.device);
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


		Debug.Log("<color=green>*********************************************************</color>");
		for (int i = 0; i < InputDevicesDetected.Length; i++)
		{		
			Debug.Log("Device detected: " + InputDevicesDetected[i].device);
			Debug.Log("DeviceID: " + InputDevicesDetected[i].deviceId);
			Debug.Log("Device displayName: " + InputDevicesDetected[i].device.displayName);
			Debug.Log("Device description: " + InputDevicesDetected[i].device.description);
			Debug.Log("<color=green>*********************************************************</color>");
		}
	}

	private void InitializePlayer()
	{
		UserControls refControls = m_refControlPool.Spawn(Vector3.zero);
		if (refControls == null)
		{
			Debug.LogError("[DeviceDetectionSystem] ");
		}
		m_lstInputControls.Add(refControls);

	}

	public void Initialize()
	{
		Debug.Log("[DeviceDetectionSystem] Initialize");
		InputSystem.onDeviceChange += DeviceDetected;

		InputDevicesDetected = new InputDevice[InputSystem.devices.ToArray().Length];
		InputDevicesDetected = InputSystem.devices.ToArray();


		InitializePlayer();
	}
}
