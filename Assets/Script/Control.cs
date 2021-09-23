using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            playerPos.x -= 0.4f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerPos.x += 0.4f;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 0, 1);
        }

        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 0, -1);
        }

        transform.position = playerPos;
    }
}
