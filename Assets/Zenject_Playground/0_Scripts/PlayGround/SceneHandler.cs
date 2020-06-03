using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class SceneHandler : MonoBehaviour, ISceneUpdate, IInitializable
{
	private IGameState m_refGameState;

	public void Initialize()
	{
		Debug.Log("[SceneHandler] Initialized");
	}

	public void LoadScene(int a_iBuildIndex)
	{
		SceneManager.LoadScene(a_iBuildIndex, LoadSceneMode.Single);
	}

}
