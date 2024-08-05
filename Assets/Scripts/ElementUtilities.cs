using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ElementUtilities : MonoBehaviour
{
    public IEnumerator CheckMoving(SpriteRenderer principalSR, GameObject principal, GameObject target)
    {
        yield return new WaitForSeconds(0);

        if (principal.transform.position.x > target.transform.position.x)
        {
            principalSR.flipX = true;
        }
        else if (principal.transform.position.x < target.transform.position.x)
        {
            principalSR.flipX = false;
        }
    }
}
