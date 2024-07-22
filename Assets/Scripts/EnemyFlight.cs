using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyFlight : MonoBehaviour
{
    public FollowingTarget followingTarget;
    public GameObject flightPoint;
    public bool canMove = true;
    public Transform[] moveSpots;
    private int i = 0;
    public float speed = 1.2f;
    

    void Update()
    {
        if (!followingTarget.canFollow && canMove)
        {
            //StartCoroutine(CheckMoving());
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    canMove = false;
                }
            }
        }
    }
}
