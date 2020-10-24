using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : BaseActivatable
{
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (  CanOnlyActivateOnce == false || (CanOnlyActivateOnce == true && DidActivateOnce == false))
		{
			DidActivateOnce = true;
			InvokeOnActive();
		}
	}

	//when the player leaves
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (CanOnlyActivateOnce == false || (CanOnlyActivateOnce == true && DidDeActivateOnce == false))
		{
			DidDeActivateOnce = true;
			InvokeOnDeActive();
		}
	}
}
