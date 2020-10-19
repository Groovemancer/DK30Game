using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *	The Player Charater Manager is in charge of the two player characters 
 * 
 */

public class PlayerCharatersManager : MonoBehaviour
{
	[Header("Character Prefabs")]
	public GameObject OnePrefab;
	public GameObject TwoPrefab;

	private GameObject One;
	private GameObject Two;

	[Header("Scene Locations")]
	public GameObject PlayerOneSpawnLocation;
	public GameObject PlayerTwoSpawnLocation;

	//respawn location? can we die?
	//public GameObject PlayerOneSpawnLocation;
	//public GameObject PlayerTwoSpawnLocation;

	[Header("PlayerManager Variables")]
	private int CurrentControllingCharater = -1;
	private List<PlayerCharacter> PlayerControlledObjects = new List<PlayerCharacter>();

	public void Start()
	{
		SpawnPlayers();
	}

	void Update()
	{
		if (Input.GetButtonDown("SwitchControl"))
		{
			IncrementControllingCharacter();
		}
	}

	public void SpawnPlayers()
	{
		//one spawn
		if(OnePrefab != null)
		{
			One = Instantiate(OnePrefab, PlayerOneSpawnLocation.transform.position, PlayerOneSpawnLocation.transform.rotation);
			PlayerControlledObjects.Add(One.GetComponent<PlayerCharacter>());
		}

		//two spawn
		if(TwoPrefab != null)
		{
			Two = Instantiate(TwoPrefab, PlayerTwoSpawnLocation.transform.position, PlayerTwoSpawnLocation.transform.rotation);
			PlayerControlledObjects.Add(Two.GetComponent<PlayerCharacter>());
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
}
