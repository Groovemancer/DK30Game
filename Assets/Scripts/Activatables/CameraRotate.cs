using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject secCamera;
    public float degreesPerSec = 15f;
    public float sweepTime = 2f;
    public float timer = 0.00f;
    public float sweepDir = 1f;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float rotAmount = sweepDir*degreesPerSec * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;
        if(timer < sweepTime)
            {
            secCamera.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, (curRot + rotAmount)));
        }
        else
            {
                timer = 0.0f;
                sweepDir = -1*sweepDir;
            }


    }
}
