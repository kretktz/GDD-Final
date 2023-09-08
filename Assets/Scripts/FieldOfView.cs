using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius = 10f;
    [Range(1, 360)] public float angle = 60f;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;

    public GameObject playerRef;

    public Enemy enemy;

    private bool isFacingRight;

    public bool CanSeePlayer { get; private set; }
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(FOVCheck());

        isFacingRight = enemy.isFacingRight;
    }

    //minimize system load by calling the function every 0.2 seconds instead of every frame
    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FOV();
        }
    }

    private void FOV()
    {
        isFacingRight = enemy.isFacingRight;

        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        //check if there is anything in the range and layer
        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;

            Vector2 directionToTarget;

            if (isFacingRight)
            {
                directionToTarget = (target.position - transform.position).normalized;
            }
            else
            {
                directionToTarget = (-target.position + transform.position).normalized;
            }
            


            //check if target is within the angle
            if (Vector2.Angle(transform.rotation.y == 180 ? -transform.right : transform.right, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                {
                    CanSeePlayer = true;
                }
                else
                    CanSeePlayer = false;
            }
            else
                CanSeePlayer = false;
        }
        else if (CanSeePlayer)
            CanSeePlayer = false;
    }

    ////helper functions to visualize FOV
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.white;
    //    UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

    //    Vector3 angle01 = DirectionFromAngle(-angle / 2);
    //    Vector3 angle02 = DirectionFromAngle(angle / 2);

    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
    //    Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);

    //    if (CanSeePlayer)
    //    {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawLine(transform.position, playerRef.transform.position);
    //    }
    //}

    ////utility function to draw angle on the Gizmo in editor
    //private Vector2 DirectionFromAngle(float angleInDegrees)
    //{
    //    return (Vector2)(Quaternion.Euler(0, 0, angleInDegrees) * (transform.rotation.x == 180 ? -transform.right : transform.right));
    //}
}
