using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    CannonController cannonController;
    public LineRenderer lineRenderer;

    // Number of points on the line
    public int numPoints = 50;

    // distance between those points on the line
    public float timeBetweenPoints = 0.1f;

    // The physics layers that will cause the line to stop being drawn
    public LayerMask CollidableLayers;
    void Start()
    {
        cannonController = GetComponent<CannonController>();
        
    }


    void LateUpdate()
    {
        lineRenderer.positionCount = (int)numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = cannonController.ShotPoint.position;
        Vector3 startingVelocity = cannonController.ShotPoint.up * cannonController.BlastPower;

        if (Input.GetKey(KeyCode.Mouse1))
        {
            lineRenderer.enabled = true;
            for (float t = 0; t < numPoints; t += timeBetweenPoints)
            {
                Vector3 newPoint = startingPosition + t * startingVelocity;
                newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
                points.Add(newPoint);

                if (Physics.OverlapSphere(newPoint, 0.4f, CollidableLayers).Length > 0)
                {
                    lineRenderer.positionCount = points.Count;
                    break;
                }
            }

            lineRenderer.SetPositions(points.ToArray());
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}