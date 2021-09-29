using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum Enemy { Player1, Player2 };
    public Enemy enemyId;
    public static int winner = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), transform.root.GetComponent<Collider>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameStart.started)
        {
            if (other.name.StartsWith(enemyId.ToString()))
            {
                if (other.name == "Player2")
                {
                    winner = 1;
                }
                else if (other.name == "Player1")
                {
                    winner = 2;
                }
                print(other.name);
                Destroy(gameObject);
            }
    
        }
    }
}
