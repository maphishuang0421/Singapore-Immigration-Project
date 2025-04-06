using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Transform portal;

    // Update is called once per frame
    void Update()
    {
        /* Vector3 vector = portal.position - transform.position;
        var angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); */

        float angle = Mathf.Atan2(portal.position.y - transform.position.y, portal.position.x - transform.position.x)* Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360);
        
    }
}
