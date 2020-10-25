using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Destination;
    public GameObject Player;
    public int delayToDeActivate;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            StartCoroutine(TeleportPlayer());
        }
    }

    IEnumerator TeleportPlayer()
    {
        
        yield return new WaitForSeconds(1);
        Player.transform.position = new Vector2(Destination.transform.position.x, Destination.transform.position.y);
    }
}
