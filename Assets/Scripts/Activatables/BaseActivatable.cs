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
[RequireComponent(typeof(SpriteRenderer))]
public abstract class BaseActivatable : MonoBehaviour
{
	public UnityEvent OnActiveEvents;
	public UnityEvent OnDeActiveEvents;

	public Sprite SpriteActiveState;
	public Sprite SpriteDeActiveState;

	
	protected SpriteRenderer spriteRenderer;

	protected float DoubleTapPreventionDelay = .5f;
	protected float LastActivated = 0;
	protected bool isActive = false;

	protected void InvokeOnActive()
	{
		if(SpriteDeActiveState != null)
		{
			spriteRenderer.sprite = SpriteDeActiveState;
		}
		OnActiveEvents.Invoke();
	}

	protected void InvokeOnDeActive()
	{
		if (SpriteActiveState != null)
		{
			spriteRenderer.sprite = SpriteActiveState;
		}
		OnDeActiveEvents.Invoke();
	}

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
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
