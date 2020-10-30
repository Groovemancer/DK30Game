using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveBetweenTargets : MonoBehaviour
{
	public GameObject[] TargetList;
	private int CurrentTargetIndex;

	public float Speed;
	public float StopDistance;
	private bool IsStopped = true;

	public UnityEvent OnGetToTarget;

	private void Update()
	{
		if (TargetList[CurrentTargetIndex] != null)
		{
			float DistanceAway = Vector3.Distance(this.transform.position, TargetList[CurrentTargetIndex].transform.position);
			if (DistanceAway > StopDistance)
			{
				IsStopped = false;
				transform.position = Vector3.MoveTowards(this.transform.position, TargetList[CurrentTargetIndex].transform.position, Speed / 1000);
			}
			else
			{
				if (IsStopped == false)
				{
					IsStopped = true;
					OnGetToTarget.Invoke();
					CurrentTargetIndex++;
		
					if (CurrentTargetIndex > TargetList.Length - 1)
					{
						CurrentTargetIndex = 0;
					}
				}
			}
		}
	}

}
