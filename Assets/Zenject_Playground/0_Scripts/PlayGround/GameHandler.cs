using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameHandler : MonoBehaviour
{
	private IGameState m_refGameState;
	private ISceneUpdate m_refSceneUpdate;

	[Inject]
	private void Construct(IGameState a_refGameState, ISceneUpdate a_refSceneUpdate)
	{
		m_refGameState = a_refGameState;
		m_refSceneUpdate = a_refSceneUpdate;
	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneChange;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneChange;
	}

	void Start()
    {
		
	}

    void Update()
    {
		if (m_refGameState == null)
			return;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (m_refGameState.EGameState == Utility.States.eGameState.Intro)
			{
				m_refSceneUpdate.LoadScene(1);
			}
			else if (m_refGameState.EGameState == Utility.States.eGameState.Game)
			{
				m_refSceneUpdate.LoadScene(2);
			}
			else if (m_refGameState.EGameState == Utility.States.eGameState.Outro)
			{
				m_refSceneUpdate.LoadScene(0);
			}
		}
	}

	void OnSceneChange(Scene a_scene, LoadSceneMode a_loadSceneMode)
	{
		switch(a_scene.buildIndex)
		{
			case 0:
				m_refGameState.EGameState = Utility.States.eGameState.Intro;
				Debug.Log("[Gamehandler] GameState: " + m_refGameState.EGameState);
				break;
			case 1:
				m_refGameState.EGameState = Utility.States.eGameState.Game;
				Debug.Log("[Gamehandler] GameState: " + m_refGameState.EGameState);
				break;
			case 2:
				m_refGameState.EGameState = Utility.States.eGameState.Outro;
				Debug.Log("[Gamehandler] GameState: " + m_refGameState.EGameState);
				break;
		}
	}
}
