using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * Base class for interactable objects. 
 * 
 * This is ment to be extened into different ways to activate ie a button, lever, and pressureplate. 
 *  
 *  
 *  **update is only called when the player is in range
 */

public abstract class BaseActivatable : MonoBehaviour
{
	public UnityEvent OnActiveEvents;
	public UnityEvent OnDeActiveEvents;

	protected float DoubleTapPreventionDelay = .5f;
	protected float LastActivated = 0;

	
	protected void InvokeOnActive()
	{
		OnActiveEvents.Invoke();
	}

	protected void InvokeOnDeActive()
	{
		OnDeActiveEvents.Invoke();
	}

	private void Start()
	{
		this.enabled = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//print("Player is in range");
		this.enabled = true;
	}

	//when the player leaves
	private void OnTriggerExit2D(Collider2D collision)
	{
		//print("Player left");
		this.enabled = false;
	}

}
