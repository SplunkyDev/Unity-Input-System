using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using Zenject;
using Utility.Controls;

public class UserControls : MonoBehaviour, IUserControl
{
	public PlayerInput RefPlayerInput { get; private set; }
	private m_delUserChangedController UserSwitchedController;

	private void Awake()
	{
		RefPlayerInput = GetComponent<PlayerInput>();	
	}

	private void OnEnable()
	{
		//RefPlayerInput.onControlsChanged += UserChangedControls;
		InputUser.onChange += UserChangedControls;
	}

	private void OnDisable()
	{
		//RefPlayerInput.onControlsChanged -= UserChangedControls;
		InputUser.onChange -= UserChangedControls;
	}

	private void Initialize(Vector3 a_vec3Position)
	{
		transform.position = a_vec3Position;
	}

	//public void UserChangedControls(PlayerInput a_refPlayerInput)
	//{
	//	Debug.Log("[UserCOntrols] CHnaged Controls: " + a_refPlayerInput.currentActionMap);
	//}

	public void RegisterToEvent(m_delUserChangedController a_event)
	{
		UserSwitchedController += a_event;
	}

	public void DeRegisterToEvent(m_delUserChangedController a_event)
	{
		UserSwitchedController -= a_event;
	}

	public void UserChangedControls(InputUser user, InputUserChange change, InputDevice device)
	{
		if (change == InputUserChange.ControlSchemeChanged)
		{
			UserSwitchedController?.Invoke();
		}
	}

	public class UserControlPool : MonoMemoryPool<Vector3, UserControls>
	{
		protected override void Reinitialize(Vector3 a_vec3Position, UserControls a_refInputControls)
		{
			a_refInputControls.Initialize(a_vec3Position);
		}
	}
}
