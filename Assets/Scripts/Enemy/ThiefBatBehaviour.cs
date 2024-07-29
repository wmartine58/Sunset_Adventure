using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefBatBehaviour : MonoBehaviour
{
    public FollowingTarget followingTarget;
    public EnemyFlight EnemyFlight;
    public GameObject player;
    public float followingActivationDistance = 7f;
    public float flightActivationDistance = 0.001f;
    private bool didFollowingTargetStart = false;
    private bool didEnemyFlightStart = false;

    private void Awake()
    {
        Application.runInBackground = true;
    }
    
    private void Update()
    {
        if (!didFollowingTargetStart && Vector2.Distance(player.transform.position, transform.position) <= followingActivationDistance)
        {
            didFollowingTargetStart = true;
            Debug.Log("Distancia de activacion de followingtarget: " + Vector2.Distance(player.transform.position, transform.position));
            followingTarget.canFollow = true;
        }

        if (!didEnemyFlightStart && Vector2.Distance(player.transform.position, transform.position) <= flightActivationDistance)
        {
            didEnemyFlightStart = true;
            Debug.Log("Distancia de activacion de followingtarget: " + Vector2.Distance(player.transform.position, transform.position));
            EnemyFlight.canMove = true;
        }
    }
}
