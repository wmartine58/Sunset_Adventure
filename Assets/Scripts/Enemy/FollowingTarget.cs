using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingTarget : MonoBehaviour
{
    public bool canFollow = false;
    public float separation;
    public GameObject target;
    public float speed = 1.3f;
    public float disableDistance = 0.001f;
    public SpriteRenderer batSR;
    private ElementUtilities elementUtilities;

    private void Awake()
    {
        elementUtilities = GameObject.Find("GameUtilities").GetComponent<ElementUtilities>();
    }

    private void Update()
    {
        if (canFollow)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {

        StartCoroutine(elementUtilities.CheckMoving(batSR, this.gameObject, target));

        Vector3 separationVector = new Vector3(separation, 0, 0);

        if (transform.position.x <= target.transform.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position - separationVector, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position + separationVector, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, target.transform.position) < disableDistance)
        {
            canFollow = false;
        }
    }
}