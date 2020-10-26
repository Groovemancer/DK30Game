using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class LookAtGameObject : MonoBehaviour
{
	public GameObject Target;

	//replace update method with the following

	//public void TeleportTarget()
	//{
	//	StartCoroutine(Teleport())
	//}

	//IENorator Teleport()
	//{
		// teleporter logic here
	//}

	//remove this update method
	private void Update()
	{
		if (Target != null)
		{
			//this.transform.LookAt(Target.transform);
			Vector3 dir = Target.transform.position - transform.position;
			float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

	//Two different set targets to be flexible later, however, it just uses the first one at the moment
	//By passing in the unity event target helper you can get the gameobject of the triggering charater. 

	public void SetTarget(UnityEventTargetPasserHelper TargetInHelper)
	{
		Target = TargetInHelper.GetTarget();
	}

	public void SetTarget(GameObject TargetIn)
	{
		Target = TargetIn;
	}
}
