using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayDKButton : BaseActivatable
{
	public int delayToDeActivate;

	/* If the button is not active at the moment
	 * Waits for player to press the interactive button 
	 * else
	 * auto deactivated after a delay
	 * 
	 * -Example Minecraft button
	 */
	
	//update is only called when the player is in range
	void Update()
	{
		//print(Time.time - LastActivated);
		if (isActive == false && Time.time - LastActivated > DoubleTapPreventionDelay && Input.GetButtonDown("Activate"))
		{
			LastActivated = Time.time;
			StartCoroutine( PressButton() );
			FindObjectOfType<AudioManager>().Play("Button");
		}
	}

	IEnumerator PressButton()
	{
		isActive = true;
		InvokeOnActive();
		yield return new WaitForSeconds(delayToDeActivate);
		if (CanOnlyActivateOnce == false)
		{
			isActive = false;
		}
		InvokeOnDeActive();
	}

}
