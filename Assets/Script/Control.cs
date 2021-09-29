using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public enum Players { Player1, Player2 };
    public Players playerId;

    GameObject playerMum;
    Vector3 playerPos;
    Vector3 playerPosG;
    int reverse;


    // Start is called before the first frame update
    void Start()
    {
        //print(playerId);
        playerMum = new GameObject(playerId + "_Mum");
        transform.SetParent(playerMum.transform, false);
        playerPos = transform.localPosition;

        //static bool Between(float number, float min, float max)
        //{
        //    return number >= min && number <= max;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStart.started)
        {

            playerPosG = transform.position;
            print("G:" + playerPosG);
            reverse = (playerId == Players.Player2) ? -1 : 1;
            if (Input.GetKey(KeyCode.A) & (playerId == Players.Player1) || Input.GetKey(KeyCode.J) & (playerId == Players.Player2))
            {
                playerPos.x -= reverse * ((isWithin()) ? 0.4f : -1f); //minus 1 to bounce away preventing reached exact 50
            }

            if (Input.GetKey(KeyCode.D) & (playerId == Players.Player1) || Input.GetKey(KeyCode.L) & (playerId == Players.Player2))
            {
                playerPos.x += reverse * ((isWithin()) ? 0.4f : -1f); //minus 1 to bounce away preventing reached exact 50
            }

            if (Input.GetKey(KeyCode.W) & (playerId == Players.Player1) || Input.GetKey(KeyCode.I) & (playerId == Players.Player2))
            {
                playerPos.z += reverse * ((isWithin()) ? 0.4f : -1f); //minus 1 to bounce away preventing reached exact 50
            }

            if (Input.GetKey(KeyCode.S) & (playerId == Players.Player1) || Input.GetKey(KeyCode.K) & (playerId == Players.Player2))
            {
                playerPos.z -= reverse * ((isWithin()) ? 0.4f : -1f); //minus 1 to bounce away preventing reached exact 50
            }

            if (Input.GetKey(KeyCode.Q) & (playerId == Players.Player1) || Input.GetKey(KeyCode.U) & (playerId == Players.Player2))
            {
                //transform.Rotate(0, 0, 1);  // Rotate Z-Asix is non-sense
                playerMum.transform.RotateAround(transform.position, Vector3.up, 1);
            }

            if (Input.GetKey(KeyCode.E) & (playerId == Players.Player1) || Input.GetKey(KeyCode.P) & (playerId == Players.Player2))
            {
                //transform.Rotate(0, 0, -1);  // Rotate Z-Asix is non-sense
                playerMum.transform.RotateAround(transform.position, Vector3.up, -1);
            }

            transform.localPosition = playerPos;

            // Make Sure players inside the board, and don't go out
            dontGoOut();


        }
    }

    public bool isWithin()
    {
        if (playerPosG.x < 50 & playerPosG.x > -50 & playerPosG.z < 50 & playerPosG.z > -50)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void dontGoOut()
    {
        playerPos.x -= (playerPosG.x > 50) ? 1f : 0f;
        playerPos.x += (playerPosG.x < -50) ? 1f : 0f;
        playerPos.z -= (playerPosG.z > 50) ? 1f : 0f;
        playerPos.z += (playerPosG.z < -50) ? 1f : 0f;

        transform.localPosition = playerPos;
    }

}
