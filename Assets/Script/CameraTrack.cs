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
    Vector3 camPosDiff;
    Quaternion camRotDiff;
    float speedPos = 6f;
    float speedRot = 60f;
    GameObject camTarget;
    int reverse;

    // Start is called before the first frame update
    void Start()
    {
        reverse = (playerId == Players.Player2) ? -1 : 1;
        camTarget = new GameObject(playerId + "_camTarget");
        camTarget.transform.position = transform.position;
        camTarget.transform.rotation = transform.rotation;
        camTarget.transform.SetParent(target);
        //camPosDiff = (playerId == Players.Player1) ? new Vector3(camDistantZ : -camDistantZ;
        camPosDiff = transform.position - target.position;
        camRotDiff = transform.rotation * Quaternion.Inverse(target.rotation);
        //print(camPosDiff);
        //print(camRotDiff);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - reverse*4);  //Make camera slightly zoom at the beginning
        transform.RotateAround(target.position, Vector3.up, 45); //Make camera slightly rotated at the beginning to see emery
    }

    // Update is called once per frame
    void Update()
    {

        //----- Task 2 -----
        if (GameStart.started)
        {
            pos = Vector3.Lerp(transform.position, camTarget.transform.position, Time.deltaTime * speedPos);
            transform.position = pos;

            Quaternion currentRot = transform.rotation;
            //Quaternion targetRot = target.transform.rotation * camRotDiff;
            transform.rotation = Quaternion.RotateTowards(currentRot, camTarget.transform.rotation, Time.deltaTime * speedRot);

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
