using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CreateGrid cg;

    public float speed = 1.0f;

    private bool playersTurn = true;

    private void Update()
    {
        Vector3 pos = transform.position;

        if (playersTurn && Input.anyKey)
        {
            if (Input.GetKey("w"))
            {
                transform.position = pos + Vector3.forward;
            }
            else if (Input.GetKey("s"))
            {
                transform.position = pos + Vector3.back;
            }
            else if (Input.GetKey("d"))
            {
                transform.position = pos + Vector3.right;
            }
            else if (Input.GetKey("a"))
            {
                transform.position = pos + Vector3.left;
            }

            playersTurn = false;
        }
    }
}
