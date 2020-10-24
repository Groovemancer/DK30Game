using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerDK : MonoBehaviour
{
	public string NextSceneName;
	/*
	 * True - saves the scene you are transitioning too the player prefs to be able to continue 
	 * 
	 * False - does not save
	 */
	public bool SaveNextSceneToPlayerPrefs = false;

	public void LoadNextScene()
	{
		if(SaveNextSceneToPlayerPrefs == true)
		{
			PlayerPrefs.SetString("ContinueLevel", NextSceneName);
		}

		SceneManager.LoadScene(NextSceneName);
	}

	public void LoadContinueLevelScene()
	{
		string ContinueLevelScene = PlayerPrefs.GetString("ContinueLevel","None");
		
		if (ContinueLevelScene != "None")
		{
			SceneManager.LoadScene(ContinueLevelScene);
		}
	}
}
