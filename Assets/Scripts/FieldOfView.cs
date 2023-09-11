using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FieldOfView : MonoBehaviour
{
    public float radius = 10f;
    [Range(1, 360)] public float angle = 60f;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;

    public GameObject playerRef;

    public Enemy enemy;

    public Light2D lt;

    private bool isFacingRight;

    public bool CanSeePlayer { get; private set; }
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(FOVCheck());

        isFacingRight = enemy.isFacingRight;

        lt.color = Color.yellow;
    }

    //minimize system load by calling the function every 0.2 seconds instead of every frame
    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.01f);

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

            Vector3 shiftUp;

            shiftUp = new Vector3(0.0f, 3.0f, 0.0f);

            Vector2 directionToTarget;
            float distanceToTarget;

            if (isFacingRight)
            {
                directionToTarget = (target.position - transform.position);
                distanceToTarget = Vector2.Distance(transform.position, target.position);
            }
            else
            {
                directionToTarget = -(target.position - transform.position);
                distanceToTarget = Vector2.Distance(transform.position, target.position)/2;
            }

            //check if target is within the angle
            if (Vector2.Angle(transform.rotation.y == 180 ? -transform.right : transform.right, directionToTarget) < angle / 2)
            {
                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer) &&
                    isFacingRight)
                {
                    CanSeePlayer = true;
                }
                else if (!Physics2D.Raycast(target.position, directionToTarget, distanceToTarget, obstructionLayer) &&
                    !isFacingRight)
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

        if(CanSeePlayer)
        {
            
            FindObjectOfType<Manager>().EndGame();
        }

        ChangeLight();

        
    }

    public void ChangeLight()
    {
        if(CanSeePlayer)
        {
            lt.color = Color.red;
        }
        else
        {
            lt.color = Color.yellow;
        }
        
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
