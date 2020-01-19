using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  caps cherry blossom speed 
 * 
 */

public class CherryBlossomUI : MonoBehaviour
{
    private static readonly float MAX_SPEED = 2.5f;
    private Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (myRigidbody.velocity.magnitude > MAX_SPEED)
        {
            myRigidbody.velocity = myRigidbody.velocity.normalized * MAX_SPEED;
        }
    }
}
