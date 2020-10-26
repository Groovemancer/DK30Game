using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeRepeating : MonoBehaviour
{

	public UnityEvent FirstActivationEvents;
	public UnityEvent SecondActivationEvents;

	public float delayBetweenCalls;

	public float startDelay = 0f;
	public float delayBefore2ndEvent = 1f; 

	// Start is called before the first frame update
	void Start()
	{
		InvokeRepeating("FirstEvents", startDelay, delayBetweenCalls);
	}

	private void FirstEvents()
	{
		FirstActivationEvents.Invoke();
		Invoke("SecondEvents", delayBefore2ndEvent);
	}

	private void SecondEvents()
	{
		SecondActivationEvents.Invoke();
	}

}
