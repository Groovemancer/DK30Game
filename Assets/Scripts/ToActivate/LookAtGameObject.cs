using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtGameObject : MonoBehaviour
{
	public GameObject Target;

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

	public void SetTarget(UnityEventTargetPasserHelper TargetInHelper)
	{
		Target = TargetInHelper.GetTarget();
	}

	public void SetTarget(GameObject TargetIn)
	{
		Target = TargetIn;
	}
}
