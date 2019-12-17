using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    bool playersTurn;
    readonly int BOUNDS = 4;

    // Start is called before the first frame update
    void Start()
    {
        playersTurn = true;
    }

    private void Update()
    {
        if (playersTurn)
        {
            onTurn();
        }
        else if (!playersTurn)
        {
            StartCoroutine(ExampleCoroutine());
        }
    }

    void onTurn()
    {
        if (Input.anyKey)
        {
            Vector3 pos = player.transform.position;

            if (Input.GetKey("w"))
            {
                player.transform.position = pos + Vector3.forward;
                playersTurn = false;
            }
            else if (Input.GetKey("s"))
            {
                player.transform.position = pos + Vector3.back;
                playersTurn = false;
            }
            else if (Input.GetKey("d"))
            {
                player.transform.position = pos + Vector3.right;
                playersTurn = false;
            }
            else if (Input.GetKey("a"))
            {
                player.transform.position = pos + Vector3.left;
                playersTurn = false;
            }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        while (!playersTurn)
        {
            Vector3 pos = enemy.transform.position;
            int direction = Random.Range(1, 5);

            if (direction == 1 && pos.z < BOUNDS)
            {
                enemy.transform.position = pos + Vector3.forward;
                playersTurn = true;
            }
            else if (direction == 2 && pos.z > -BOUNDS)
            {
                enemy.transform.position = pos + Vector3.back;
                playersTurn = true;
            }
            else if (direction == 3 && pos.x < BOUNDS)
            {
                enemy.transform.position = pos + Vector3.right;
                playersTurn = true;
            }
            else if (direction == 4 && pos.x > -BOUNDS)
            {
                enemy.transform.position = pos + Vector3.left;
                playersTurn = true;
            }
        }

        // yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
    }

}
