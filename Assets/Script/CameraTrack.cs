using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{

    public enum Players { Player1, Player2 };
    public Players playerId;
    public Transform target;

    //Quaternion rot;   //[To Be Check] Error: unity Object reference not set to an instance of an object
    Vector3 pos;
    float rotOpposite;
    int camDistantZ = 8;
    int camDistantY = 2;
    float speedPos = 6f;
    float speedRot = 40f;
 
    // Start is called before the first frame update
    void Start()
    {
        camDistantZ = (playerId == Players.Player1) ? camDistantZ : -camDistantZ;
    }

    // Update is called once per frame
    void Update()
    {

        //----- Task 2 -----
        if (GameStart.started)
        {

            pos = Vector3.Lerp(transform.position,
                new Vector3(target.position.x, target.position.y + camDistantY, target.position.z - camDistantZ),
                Time.deltaTime * speedPos);
            transform.position = pos;

            //Quaternion currentRot = transform.rotation;
            //Quaternion targetRot = target.transform.rotation;
            //transform.rotation = Quaternion.RotateTowards(currentRot, targetRot, Time.deltaTime * speedRot);

        }
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
