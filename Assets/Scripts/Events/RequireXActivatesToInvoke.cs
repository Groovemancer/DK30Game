using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RequireXActivatesToInvoke : MonoBehaviour
{
	public int RequiredXToActivate;
	private int timesActivated = 0;
	private bool didInvoke = false;

	public UnityEvent OnActivedXtimesEvents;


	public void Activate()
	{
		if (didInvoke == true )
		{
			return;
		}
		timesActivated++;
		if (timesActivated >= RequiredXToActivate )
		{
			OnActivedXtimesEvents.Invoke();
		}
	}
}
