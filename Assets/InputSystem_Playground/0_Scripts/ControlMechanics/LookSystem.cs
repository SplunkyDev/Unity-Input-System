using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class LookSystem : MonoBehaviour, ILook
{
	public Vector2 Vec2Look { get; private set; }
	public bool BEnableInput { get; private set; }
	private Vector2 m_vec2PrevValue = Vector2.zero;

	private InputController m_refInputControls;
	private IUserControl m_refUserControl;

	[SerializeField]
	private float m_fRotationSpeed = 5;
	private float m_fYaxis, m_fXaxis =0;

	[Inject]
	void Init(InputController a_refInputControls)
    {
		Debug.Log("[LookSystem] Init");

		m_refInputControls = a_refInputControls;
		m_refInputControls.Player.Enable();
		m_refInputControls.Player.Look.performed += Look;
	}

	private void Awake()
	{
		BEnableInput = false;
	}

	void OnEnable()
	{
		m_refUserControl = GetComponent<IUserControl>();
		if (m_refUserControl == null)
			return;

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
		Debug.Log("[LookSystem] Switched Controls ");
	}

	void Update()
    {
		if (!BEnableInput)
			return;

		m_fYaxis += Vec2Look.x * m_fRotationSpeed * Time.deltaTime;
		m_fXaxis -= Vec2Look.y * m_fRotationSpeed * Time.deltaTime;

		transform.localEulerAngles = new Vector3(m_fXaxis, 0, 0);
		transform.parent.eulerAngles = new Vector3(0, m_fYaxis, 0);
	}


	public void Look(InputAction.CallbackContext callbackContext)
	{
		BEnableInput = true;
		Vec2Look = callbackContext.ReadValue<Vector2>().normalized;
	}
}
