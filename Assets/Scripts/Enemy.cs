﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int pauseDuration;

    [SerializeField]
    private Vector3[] positions;

    private bool isMoving;
    private int index;
    public bool isFacingRight;
    private float latestDirectionChangeTime;

    private void Start()
    {
        latestDirectionChangeTime = 0f;

        isMoving = true;
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsMoving", isMoving);

        // Logic handling the pause at the end of patrol
        if (Time.time - latestDirectionChangeTime > pauseDuration)
        {
            latestDirectionChangeTime = Time.time;
            if (transform.position == positions[index]) // reched the end of path
            {
                if (index == positions.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
                Flip();
            }
        }

        if (transform.position == positions[index])
        {
            isMoving = false; //play idle animation
        }

        Move();
    }

    private void Flip()
    {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            isMoving = true;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);
    }
}
