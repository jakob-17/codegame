using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    [SerializeField]
    private float size = 1f;

    List<Vector3> points = new List<Vector3>();

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (float x = 0; x < 9; x += size)
        {
            for (float z = 0; z < 9; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.05f);

                points.Add(point);
            }
        }
        // draw vertical lines
        for (int i = 0; i < 81; i += 9)
        {
            for (int k = 1 * i; k < 1 * i + 9 - 1; k++)
            {
                Gizmos.DrawLine(points[k], points[k + 1]);
            }
        }
        // draw horizontal lines
        for (int i = 0; i < 81; i += 9)
        {
            for (int k = 1 * i; k < 1 * i + 9; k++)
            {
                Gizmos.DrawLine(points[k], points[k + 9]);
            }
        }
    }
}
