using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.States;
using Zenject;

public class GameStateHandler : MonoBehaviour, IGameState, IInitializable
{
	private Utility.States.eGameState m_enumGameState;
	public eGameState EGameState { get => m_enumGameState; set => m_enumGameState = value; }

	public void Initialize()
	{
		Debug.Log("[GameStateHandler] Initialized");
		Debug.Log("[GameStateHandler] GameState: " + EGameState);
	}
}
