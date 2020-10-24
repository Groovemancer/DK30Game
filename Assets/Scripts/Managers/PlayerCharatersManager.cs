using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *	The Player Charater Manager is in charge of the two player characters 
 * 
 */
public enum PlayerSpawnRule { BOTH, ONE_ONLY, TWO_ONLY, NONE };


public class PlayerCharatersManager : MonoBehaviour
{



	[Header("Character Prefabs")]
	public PlayerSpawnRule WhatSpawnsOnStart;
	public GameObject OnePrefab;
	public GameObject TwoPrefab;

	private GameObject One;
	private GameObject Two;

	private bool IsOneSpawned = false;
	private bool IsTwoSpawned = false;

	[Header("Scene Locations")]
	public GameObject PlayerOneSpawnLocation;
	public GameObject PlayerTwoSpawnLocation;

	//respawn location? can we die?
	//public GameObject PlayerOneSpawnLocation;
	//public GameObject PlayerTwoSpawnLocation;

	private int CurrentControllingCharater = -1;
	private List<PlayerCharacter> PlayerControlledObjects = new List<PlayerCharacter>();

	public void Start()
	{
		InitialSpawnPlayers();
	}

	void Update()
	{
		if (Input.GetButtonDown("SwitchControl"))
		{
			IncrementControllingCharacter();
		}
	}

	public void InitialSpawnPlayers()
	{
		//one spawn
		if (OnePrefab != null && (WhatSpawnsOnStart == PlayerSpawnRule.BOTH || WhatSpawnsOnStart == PlayerSpawnRule.ONE_ONLY) )
		{
			SpawnPlayerOne();
		}

		//two spawn
		if(TwoPrefab != null && (WhatSpawnsOnStart == PlayerSpawnRule.BOTH || WhatSpawnsOnStart == PlayerSpawnRule.TWO_ONLY))
		{
			SpawnPlayerTwo();
		}

		if (CurrentControllingCharater == -1 && PlayerControlledObjects.Count != 0)
		{
			CurrentControllingCharater = 0;
			EnableControl(0);
		}
	}

	public void IncrementControllingCharacter()
	{
		//returns if there is only 1 object to control
		if (PlayerControlledObjects.Count <= 1)
		{
			return;
		}

		//enables the next object in the list to be controlled 
		//and disables the current object
		DisableControl(CurrentControllingCharater);

		CurrentControllingCharater++;
		if(CurrentControllingCharater >= PlayerControlledObjects.Count)
		{
			CurrentControllingCharater = 0;
		}

		EnableControl(CurrentControllingCharater);
	}

	public void EnableControl(int index)
	{
		if (PlayerControlledObjects[index] != null)
		{
			PlayerControlledObjects[index].EnableControl();
		}
	}

	public void DisableControl(int index)
	{
		if (PlayerControlledObjects[index] != null)
		{
			PlayerControlledObjects[index].DisableControl();
		}
	}

	public void AddObjToControl(PlayerCharacter toAdd)
	{
		if (!PlayerControlledObjects.Contains(toAdd))
		{
			PlayerControlledObjects.Remove(toAdd);
		}
	}

	public void RemoveObjToControl(PlayerCharacter toRemove)
	{
		if (PlayerControlledObjects.Contains(toRemove))
		{
			PlayerControlledObjects.Remove(toRemove);
		}
	}

	public void SpawnPlayerOne()
	{
		if(IsOneSpawned == false)
		{
			One = Instantiate(OnePrefab, PlayerOneSpawnLocation.transform.position, PlayerOneSpawnLocation.transform.rotation);
			PlayerControlledObjects.Add(One.GetComponent<PlayerCharacter>());
			IsOneSpawned = true;
		}
	}

	public void SpawnPlayerTwo()
	{
		if (IsTwoSpawned == false)
		{
			Two = Instantiate(TwoPrefab, PlayerTwoSpawnLocation.transform.position, PlayerTwoSpawnLocation.transform.rotation);
			PlayerControlledObjects.Add(Two.GetComponent<PlayerCharacter>());
			IsTwoSpawned = true;
		}
	}

}
