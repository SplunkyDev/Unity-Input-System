using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class MoveSystem : MonoBehaviour, IMove
{
	public bool BEnableInput { get; private set; }

	public Vector2 Vec2Move { get; private set; }
	private Vector2 m_vec2PrevValue = Vector2.zero;

	private InputController m_refInputControls;
	private IUserControl m_refUserControl;

	[SerializeField]
	private float m_fwalkSpeed = 5;

	[Inject]
	void Init(InputController a_refInputControls)
	{
		Debug.Log("[MoveSystem] Init");

		m_refInputControls = a_refInputControls;
		m_refInputControls.Player.Enable();
		m_refInputControls.Player.Move.performed += Move;
	}

	void OnEnable()
	{
		m_refUserControl = GetComponent<IUserControl>();
		m_refUserControl.RegisterToEvent(UserSwitchedControl);
	}

	void OnDisable()
	{
		if (m_refUserControl == null)
			return;

		m_refUserControl.DeRegisterToEvent(UserSwitchedControl);
	}

	void UserSwitchedControl()
	{
		BEnableInput = false;
		Debug.Log("[MoveSystem] Switched Controls ");
	}
	// Start is called before the first frame update
	void Start()
    {
		Vec2Move = Vector3.zero;
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(new Vector3(Vec2Move.x, 0, Vec2Move.y) * Time.deltaTime * m_fwalkSpeed, Space.Self);
	}

	public void Move(InputAction.CallbackContext callbackContext)
	{
		BEnableInput = true;
		Vec2Move = callbackContext.ReadValue<Vector2>().normalized;
		//Debug.Log("Move Input: " + Vec2Move);
	}
}
