using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
	public GameObject Target;

	public void SetTarget(GameObject TargetIn)
	{
		Target = TargetIn;
	}
}
