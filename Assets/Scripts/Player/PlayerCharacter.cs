using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	public PlayerMovment playerMovement;

	
	public void EnableControl()
	{
		playerMovement.enabled = true;
	}

	public void DisableControl()
	{
		playerMovement.enabled = false;
	}
}
