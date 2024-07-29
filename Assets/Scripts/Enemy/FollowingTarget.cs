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
    public SpriteRenderer spriteRenderer;

    private void Update()
    {
        if (canFollow)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {

        StartCoroutine(CheckMoving());

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

    private IEnumerator CheckMoving()
    {
        yield return new WaitForSeconds(0);

        if (transform.position.x > target.transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (transform.position.x < target.transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }
}