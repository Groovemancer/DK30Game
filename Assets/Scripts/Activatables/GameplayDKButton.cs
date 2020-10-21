using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayDKButton : BaseActivatable
{
	public int delayToDeActivate;
	private bool isActive = false;


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
		if(isActive == false)
		{
			//print(Time.time - LastActivated);
			if (Time.time - LastActivated > DoubleTapPreventionDelay && Input.GetButtonDown("Activate"))
			{
				LastActivated = Time.time;
				isActive = true;
				InvokeOnActive();
			}
		}
		else
		{
			if(Time.time - LastActivated > delayToDeActivate)
			{
				isActive = false;
				InvokeOnDeActive();
			}
		}
	}

}
