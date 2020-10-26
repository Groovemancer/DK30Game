using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEventTargetPasserHelper : MonoBehaviour
{
	public GameObject TargetToPass;

	public void SetTarget(GameObject GameObjectIn)
	{
		TargetToPass = GameObjectIn;
	}

	public GameObject GetTarget()
	{
		return TargetToPass;
	}
	
}
