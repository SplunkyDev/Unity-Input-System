using UnityEngine.InputSystem;
using UnityEngine;

public interface ILook 
{
	Vector2 Vec2Look { get; }
	bool BEnableInput { get; }
	void Look(InputAction.CallbackContext callbackContex);
}
