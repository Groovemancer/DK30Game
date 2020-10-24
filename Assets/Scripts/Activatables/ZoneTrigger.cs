using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : BaseActivatable
{
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		InvokeOnActive();
	}

	//when the player leaves
	private void OnTriggerExit2D(Collider2D collision)
	{
		InvokeOnDeActive();
	}
}
