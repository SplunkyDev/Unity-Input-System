/// <summary>
/// This interface is used to instantiate the controls for the user.
/// </summary>
/// 

using UnityEngine.InputSystem;
using Utility.Controls;

public interface IUserControl 
{
	PlayerInput RefPlayerInput { get; }
	void RegisterToEvent(m_delUserChangedController a_event);
	void DeRegisterToEvent(m_delUserChangedController a_event);
}
