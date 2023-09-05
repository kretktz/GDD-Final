using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float pauseDuration;

    [SerializeField]
    private Vector3[] positions;

    private int index;
    private bool isFacingRight = true;
    private float latestDirectionChangeTime;

    private void Start()
    {
        latestDirectionChangeTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - latestDirectionChangeTime > pauseDuration)
        {
            latestDirectionChangeTime = Time.time;
            if (transform.position == positions[index])
            {
                if (index == positions.Length - 1)
                {
                    index = 0;
                    Flip();
                }
                else
                {
                    index++;
                    Flip();
                }
            }
        }

        Move();
    }

    private void Flip()
    {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);
    }
}
