using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerDK : MonoBehaviour
{
	public string TargetSceneName;
	/*
	 * True - saves the scene you are transitioning too the player prefs to be able to continue 
	 * 
	 * False - does not save
	 */
	public bool DoSaveSceneToContinue = false;

	public void LoadTargetScene()
	{
		if(DoSaveSceneToContinue == true)
		{
			PlayerPrefs.SetString("ContinueLevel", TargetSceneName);
		}

		SceneManager.LoadScene(TargetSceneName);
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
