using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject brief;
    public GameObject gameOver;
    public GameObject player1Win;
    public GameObject player2Win;
    public static bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        brief.SetActive(true);
        gameOver.SetActive(false);
        player1Win.SetActive(false);
        player2Win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !started)
        {
            print("Yeah");
            started = true;
            brief.SetActive(false);
            gameOver.SetActive(false);
            player1Win.SetActive(false);
            player2Win.SetActive(false);
        }
        if (Bullet.winner == 1)
        {
            started = false;
            gameOver.SetActive(true);
            player1Win.SetActive(true);
        }
        if (Bullet.winner == 2)
        {
            started = false;
            gameOver.SetActive(true);
            player2Win.SetActive(true);
        }
    }
}
