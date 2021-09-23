using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public enum Players { Player1, Player2 };
    public Players playerId;

    Vector3 playerPos;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = transform.position;
        //print(playerId);
    }

    // Update is called once per frame
    void Update()
    {
        //print(playerPos.x);
        if (Input.GetKey(KeyCode.A) & string.Equals(playerId, Players.Player1) || Input.GetKey(KeyCode.Semicolon) & string.Equals(playerId, Players.Player2))
        {
            playerPos.x -= (playerPos.x > -50) ? 0.4f : 0f;
        }

        if (Input.GetKey(KeyCode.S) & string.Equals(playerId, Players.Player1) || Input.GetKey(KeyCode.Quote) & string.Equals(playerId, Players.Player2))
        {
            playerPos.x += (playerPos.x < 50) ? 0.4f : 0f;
        }

        if (Input.GetKey(KeyCode.Q) & string.Equals(playerId, Players.Player1) || Input.GetKey(KeyCode.LeftBracket) &string.Equals(playerId, Players.Player2))
        {
            transform.Rotate(0, 0, 1);
        }

        if(Input.GetKey(KeyCode.W) & string.Equals(playerId, Players.Player1) || Input.GetKey(KeyCode.RightBracket) & string.Equals(playerId, Players.Player2))
        {
            transform.Rotate(0, 0, -1);
        }


        transform.position = playerPos;
    }
}
