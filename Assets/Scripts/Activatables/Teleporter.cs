using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : BaseActivatable
{
    // Start is called before the first frame update
    public Transform Destination;
    public GameObject Player;
    //public Light Teleporter_Light;
    public int delayToDeActivate;

    //
    void Start()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        if (isActive == false && Time.time - LastActivated > DoubleTapPreventionDelay && Input.GetButtonDown("Activate"))
        {
            // Debug.Log("The button was pressed");
            LastActivated = Time.time;
            StartCoroutine(TeleportPlayer());
            
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("The area was entered");
         if (other.gameObject.tag == "Player")
         {
            Player = other.gameObject;
         }
    }

    IEnumerator TeleportPlayer()
    {
        //Teleporter_Light.intensity = .5f;
        isActive = true;
        InvokeOnActive();
        yield return new WaitForSeconds(delayToDeActivate);
        Player.transform.position = new Vector2(Destination.transform.position.x, Destination.transform.position.y);
        isActive = false;
        InvokeOnDeActive();
        //Teleporter_Light.intensity = 0f;
    }
}
