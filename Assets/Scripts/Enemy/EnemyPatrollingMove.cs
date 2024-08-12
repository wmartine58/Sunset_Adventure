using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrollingMove : MonoBehaviour
{
    public bool canMove = true;
    public float speed = 0.5f;
    public Transform[] moveSpots;
    private float waitTime;
    public float startWaitTime = 2;
    public float changeWayPointDistance = 0.001f;
    private int i = 0;

    void Update()
    {
        if (canMove)
        {
            //StartCoroutine(CheckMoving());
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < changeWayPointDistance)
            {
                if (waitTime <= 0)
                {
                    i = Random.Range(0, moveSpots.Length);

                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else
        {
            //if (animator != null) animator.SetBool("Idle", true);
        }
    }
}
