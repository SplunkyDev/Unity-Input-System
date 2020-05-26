using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IDeviceTypeDetected
{ 
	InputDevice[] InputDevicesDetected { get; }
	void DeviceDetected(InputDevice a_inputDevice, InputDeviceChange a_inputDeviceChange);
}
