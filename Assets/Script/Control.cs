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
    float movSpeed;
    float bounceSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movSpeed = 0.2f;
        bounceSpeed = 1f;
        reverse = (playerId == Players.Player2) ? -1 : 1;
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
            //print("G:" + playerPosG);
            if (Input.GetKey(KeyCode.A) & (playerId == Players.Player1) || Input.GetKey(KeyCode.L) & (playerId == Players.Player2))
            {
                playerPos.x -= reverse * ((IsWithin()) ? movSpeed : -bounceSpeed); //minus to bounce away preventing reached exact 50
            }

            if (Input.GetKey(KeyCode.D) & (playerId == Players.Player1) || Input.GetKey(KeyCode.Quote) & (playerId == Players.Player2))
            {
                playerPos.x += reverse * ((IsWithin()) ? movSpeed : -bounceSpeed); //minus to bounce away preventing reached exact 50
            }

            if (Input.GetKey(KeyCode.W) & (playerId == Players.Player1) || Input.GetKey(KeyCode.P) & (playerId == Players.Player2))
            {
                playerPos.z += reverse * ((IsWithin()) ? movSpeed : -bounceSpeed); //minus to bounce away preventing reached exact 50
            }

            if (Input.GetKey(KeyCode.S) & (playerId == Players.Player1) || Input.GetKey(KeyCode.Semicolon) & (playerId == Players.Player2))
            {
                playerPos.z -= reverse * ((IsWithin()) ? movSpeed : -bounceSpeed); //minus 1 to bounce away preventing reached exact 50
            }

            if (Input.GetKey(KeyCode.Q) & (playerId == Players.Player1) || Input.GetKey(KeyCode.O) & (playerId == Players.Player2))
            {
                //transform.Rotate(0, 0, 1);  // Rotate Z-Asix is non-sense
                playerMum.transform.RotateAround(transform.position, Vector3.up, -1);
            }

            if (Input.GetKey(KeyCode.E) & (playerId == Players.Player1) || Input.GetKey(KeyCode.LeftBracket) & (playerId == Players.Player2))
            {
                //transform.Rotate(0, 0, -1);  // Rotate Z-Asix is non-sense
                playerMum.transform.RotateAround(transform.position, Vector3.up, 1);
            }

            transform.localPosition = playerPos;

            // Make Sure players inside the board, and don't go out
            DontGoOut();


        }
    }

    private bool IsWithin()
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

    private void DontGoOut()
    {
        playerPos.x -= (playerPosG.x > 50) ? bounceSpeed : 0f;
        playerPos.x += (playerPosG.x < -50) ? bounceSpeed : 0f;
        playerPos.z -= (playerPosG.z > 50) ? bounceSpeed : 0f;
        playerPos.z += (playerPosG.z < -50) ? bounceSpeed : 0f;

        transform.localPosition = playerPos;
    }



}
