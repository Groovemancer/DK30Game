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
	public List<GameObject> ObjectsInRange = new List<GameObject>();

	public UnityEvent OnActiveEvents;
	public UnityEvent OnDeActiveEvents;

	public bool CanOnlyActivateOnce = false;
	protected bool DidActivateOnce = false;
	protected bool DidDeActivateOnce = false;

	public Sprite SpriteActiveState;
	public Sprite SpriteDeActiveState;

	public UnityEventTargetPasserHelper TargetPasser;

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

	void OnTriggerEnter2D(Collider2D collision)
	{
		ObjectsInRange.Add(collision.gameObject);
		SetTargetPasser();
		this.enabled = true;
	}

	//when the player leaves
	void OnTriggerExit2D(Collider2D collision)
	{
		if ( ObjectsInRange.Contains(collision.gameObject) )
		{
			ObjectsInRange.Remove(collision.gameObject);
			UnSetTargetPasser();
		}
		this.enabled = false;
	}

	public void SetTargetPasser()
	{
		if(ObjectsInRange.Count > 0 && TargetPasser != null)
		{
			TargetPasser.SetTarget(ObjectsInRange[0]);
		}
	}

	public void UnSetTargetPasser()
	{
		if (TargetPasser != null)
		{
			TargetPasser.UnSetTarget();
		}
	}

}
