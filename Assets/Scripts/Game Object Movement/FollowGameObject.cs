using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class FollowGameObject : MonoBehaviour
{
	public float Speed;
	public GameObject Target;
	public float StopDistance;
	public UnityEvent OnActiveEvents;

	private bool IsStopped = true;

	private void Update()
	{
		if (Target != null)
		{
			float DistanceAway = Vector3.Distance(this.transform.position, Target.transform.position);
			if (DistanceAway > StopDistance)
			{
				IsStopped = false;
				transform.position = Vector3.MoveTowards(this.transform.position, Target.transform.position, Speed / 1000);
			}
			else
			{
				if (IsStopped == false)
				{
					IsStopped = true;
					OnActiveEvents.Invoke();
				}
			}
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
