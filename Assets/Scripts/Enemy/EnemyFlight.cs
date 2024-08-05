using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyFlight : MonoBehaviour
{
    public GameObject flightPoint;
    public bool canMove = false;
    public float speed = 1.3f;
    public float changeMiddlePointDistance = 0.001f;
    public SpriteRenderer batSR;
    //public GameObject stolenObject;
    public SpriteRenderer stolenObjectSR;
    private ElementUtilities elementUtilities;
    private Vector2[] middlePoints;
    private bool didMiddlePointEstablished = false;
    private int i = 0;

    private void Awake()
    {
        stolenObjectSR.enabled = false;
        middlePoints = new Vector2[3];
        elementUtilities = GameObject.Find("GameUtilities").GetComponent<ElementUtilities>();
    }

    private void SetMiddlePoints()
    {
        if (!didMiddlePointEstablished)
        {
            middlePoints[0] = new Vector2(6 * (flightPoint.transform.position.x - transform.position.x) / 10 + transform.position.x, (flightPoint.transform.position.y - transform.position.y) / 10 + transform.position.y);
            middlePoints[1] = new Vector2(9 * (flightPoint.transform.position.x - transform.position.x) / 10 + transform.position.x, 9 * (flightPoint.transform.position.y - transform.position.y) / 10 + transform.position.y);
            middlePoints[2] = flightPoint.transform.position;
            stolenObjectSR.enabled = true;
            didMiddlePointEstablished = true;
        }
    }

    private void Update()
    {
        if (canMove)
        {
            SetMiddlePoints();
            transform.position = Vector2.MoveTowards(transform.position, middlePoints[i], speed * Time.deltaTime);
            StartCoroutine(elementUtilities.CheckMoving(batSR, this.gameObject, flightPoint));

            if (Vector2.Distance(transform.position, middlePoints[i]) < changeMiddlePointDistance)
            {
                if (i < middlePoints.Length - 1)
                {
                    i++;
                }
                else
                {
                    gameObject.SetActive(false);
                    canMove = false;
                }
            }
        }
    }
}
