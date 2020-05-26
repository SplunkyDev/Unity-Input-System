using UnityEngine.InputSystem;
using UnityEngine;

public interface IMove 
{
	Vector2 Vec2Move { get; }
	bool BEnableInput { get; }
	void Move(InputAction.CallbackContext callbackContext);
}
