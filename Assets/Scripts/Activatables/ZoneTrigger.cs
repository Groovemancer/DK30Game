using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : BaseActivatable
{
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		//base on trigger enter
		ObjectsInRange.Add(collision.gameObject);
		SetTargetPasser();

		//end base on trigger enter

		if (  CanOnlyActivateOnce == false || (CanOnlyActivateOnce == true && DidActivateOnce == false))
		{
			DidActivateOnce = true;
			InvokeOnActive();
		}
	}

	//when the player leaves
	void OnTriggerExit2D(Collider2D collision)
	{
		//base on trigger exit
		if (ObjectsInRange.Contains(collision.gameObject))
		{
			ObjectsInRange.Remove(collision.gameObject);
			UnSetTargetPasser();
		}
		//end base on trigger exit


		if (CanOnlyActivateOnce == false || (CanOnlyActivateOnce == true && DidDeActivateOnce == false))
		{
			DidDeActivateOnce = true;
			InvokeOnDeActive();
		}
	}
}
