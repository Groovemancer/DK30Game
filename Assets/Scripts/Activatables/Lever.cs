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
		//I do not 100% like this as its still using an update call every frame
		if (CanOnlyActivateOnce == true && DidActivateOnce == true)
		{
			return;
		}
		//print(Time.time - LastActivated);
		if (isActive == false && Time.time - LastActivated > DoubleTapPreventionDelay && Input.GetButtonDown("Activate"))
		{
			LastActivated = Time.time;
			InvokeOnActive();
			DidActivateOnce = true;
			FindObjectOfType<AudioManager>().Play("Lever");
			isActive = true;

		}
		else if(isActive == true && Time.time - LastActivated > DoubleTapPreventionDelay && Input.GetButtonDown("Activate"))
		{
			LastActivated = Time.time;
			InvokeOnDeActive();
			FindObjectOfType<AudioManager>().Play("Lever");
			isActive = false;
		}
	}
}
