using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class MoveSystemRemastered : MonoBehaviour, IMove
{
	public Vector2 Vec2Move => throw new System.NotImplementedException();

	public bool BEnableInput => throw new System.NotImplementedException();

	public void Move(InputAction.CallbackContext callbackContext)
	{
		throw new System.NotImplementedException();
	}

	[Inject]
	void Init(IInputActionCollection a_refInputAction)
	{
		Debug.Log("[MoveSystem] Init");

		a_refInputAction.Enable();
		//InputAction refInputAction = a_refInputAction;
		//a_refInputAction.Move.performed += Move;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
