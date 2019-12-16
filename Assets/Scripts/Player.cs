using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float size = 1f;

    public CreateGrid cg;

    public float speed = 1.0f;

    private void Update()
    {
        Vector3 pos = transform.position;
        float step = speed * Time.deltaTime; // calculate distance to move
        Vector3 target;

        if (Input.GetKey("w"))
        {
            target = GetNearestPointOnGrid(transform.position + new Vector3(0f, 0f, 1f));
        }
        if (Input.GetKey("s"))
        {
            target = GetNearestPointOnGrid(transform.position + new Vector3(0f, 0f, -1f));
        }
        if (Input.GetKey("d"))
        {
            target = GetNearestPointOnGrid(transform.position + new Vector3(1f, 0f, 0f));
        }
        if (Input.GetKey("a"))
        {
            target = GetNearestPointOnGrid(transform.position + new Vector3(-1f, 0f, 0f));
        }

        // use Vector3.MoveTowards to move to node ...

        transform.position = Vector3.MoveTowards(transform.position, , step);
    }

    /// <summary>
    /// Copied from CreateGrid class.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3((float)xCount * size, (float)yCount * size, (float)zCount * size);

        result += transform.position - new Vector3(4f, 0f, 4f);

        return result;
    }
}
