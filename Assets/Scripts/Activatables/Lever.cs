using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * One press activates
 * 2nd press deactives
 */

public class Lever : BaseActivatable
{
	void Update()
	{
		//print(Time.time - LastActivated);
		if (isActive == false && Time.time - LastActivated > DoubleTapPreventionDelay && Input.GetButtonDown("Activate"))
		{
			LastActivated = Time.time;
			InvokeOnActive();
			
			isActive = true;
		}
		else if(isActive == true && Time.time - LastActivated > DoubleTapPreventionDelay && Input.GetButtonDown("Activate"))
		{
			LastActivated = Time.time;
			InvokeOnDeActive();
			
			isActive = false;
		}
	}
}
