using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    public LineRenderer lineRenerer;

    public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[20];
        lineRenerer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = origin + speed * time + (Vector3)Physics2D.gravity * time * time / 2f;
            
            if (points[i].y < -5f)
            {
                lineRenerer.positionCount = i + 1;
                break;
            }
        }

        lineRenerer.SetPositions(points);
    }

    public void ClearTrajectory()
    {
        lineRenerer.positionCount = 0;
    }
}
