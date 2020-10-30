using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { LEFT = 1, RIGHT = -1};

public class OrbitGameObject : MonoBehaviour
{

	public float CurrentDistanceToTarget = 1f;
	private float DesiredDistanceToTarget;

	public float Speed = 4.0f;
	public float ChangeDistanceSpeed = .1f;
	[Range(0, 359)] public float InitialAngle = 0;
	public bool SetInitialAngle = false;
	public GameObject Target;

	private float currentAngle;
	private Vector3 newPos = new Vector3(0, 0, 0);



	private void Start()
	{
		DesiredDistanceToTarget = CurrentDistanceToTarget;
		if (SetInitialAngle == true)
		{
			currentAngle = InitialAngle;

			if (currentAngle > 360)
			{
				currentAngle = currentAngle % 360;
			}
			float angle = currentAngle * Mathf.PI * 2f / 360;
			if (Target != null)
			{
				newPos.x = Target.transform.position.x + Mathf.Cos(currentAngle) * CurrentDistanceToTarget;
				newPos.y = Target.transform.position.y + Mathf.Sin(currentAngle) * CurrentDistanceToTarget;
			}

			transform.position = newPos;
		}
	}

	void Update()
	{
		if (CurrentDistanceToTarget != DesiredDistanceToTarget)
		{
			if ( CurrentDistanceToTarget < DesiredDistanceToTarget )
			{
				CurrentDistanceToTarget = Mathf.Clamp(CurrentDistanceToTarget + ChangeDistanceSpeed, CurrentDistanceToTarget, DesiredDistanceToTarget);
			}
			else
			{
				CurrentDistanceToTarget = Mathf.Clamp(CurrentDistanceToTarget - ChangeDistanceSpeed, CurrentDistanceToTarget, DesiredDistanceToTarget);
			}
		}

		currentAngle = currentAngle + (Speed/1000);
		if(currentAngle > 360)
		{
			currentAngle = currentAngle % 360;
		}
		float angle = currentAngle * Mathf.PI * 2f / 360;
		if (Target != null)
		{
			newPos.x = Target.transform.position.x + Mathf.Cos(currentAngle) * CurrentDistanceToTarget;
			newPos.y = Target.transform.position.y + Mathf.Sin(currentAngle) * CurrentDistanceToTarget;
		}

		transform.position = Vector3.MoveTowards(this.transform.position, newPos, Speed/10);

	}
	
	public void ChangeOrbitDistance(float NewDistance)
	{
		DesiredDistanceToTarget = NewDistance;
	}

	public void ChangeSpeed(float NewSpeed)
	{
		Speed = NewSpeed;
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
