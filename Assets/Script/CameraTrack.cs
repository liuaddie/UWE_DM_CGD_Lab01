using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{

    public Transform target;

    //Quaternion rot;   //[To Be Check] Error: unity Object reference not set to an instance of an object
    Vector3 pos;
    int camDistantZ = 6;
    int camDistantY = 1;
    float speedPos = 6f;
    float speedRot = 40f;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //----- Task 2 -----
        pos = Vector3.Lerp(transform.position,
            new Vector3(target.position.x, target.position.y + camDistantY, target.position.z - camDistantZ),
            Time.deltaTime * speedPos);
        transform.position = pos;

        Quaternion currentRot = transform.rotation;
        Quaternion targetRot = target.transform.rotation;
        transform.rotation = Quaternion.RotateTowards(currentRot, targetRot, Time.deltaTime * speedRot);

        //// [To Be Check] Error: unity Object reference not set to an instance of an object
        //rot = Quaternion.Lerp(Camera.main.transform.rotation,
        //    target.transform.rotation,
        //    Time.deltaTime * speed);
        //Camera.main.transform.rotation = rot;

        ////-----Task 1-----
        //transform.position = new Vector3(
        //    target.position.x,
        //    target.position.y,
        //    target.position.z - 10);
        //Camera.main.transform.rotation = target.transform.rotation;

        ////-----Task 0-----
        //transform.LookAt(target);
    }
}
