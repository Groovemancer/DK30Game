using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeAfterXtime : MonoBehaviour
{
	public UnityEvent ActivationEvents;

	public float startDelay = 0f;

	void Start()
	{
		Invoke("InvokeEvents", startDelay);
	}

	public void InvokeEvents()
	{
		ActivationEvents.Invoke();
	}
}
