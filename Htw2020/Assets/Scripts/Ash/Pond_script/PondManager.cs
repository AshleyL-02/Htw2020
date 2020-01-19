using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Manages pond particle systems, for now (ie pond physics) 
 * 
 * this class messy af
 */

public class PondManager : MonoBehaviour
{
    private float pondRadius;
    private Vector2 pondCenterCoor;

    private bool gotPlayerTransform = false;
    private bool isPaused = true;

    //reference
    private PondRipplePS pondRipplePhysicsPS;
    private PondRipplePS pondRippleSpritePS;


    private Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        pondRadius = this.GetComponent<CircleCollider2D>().radius;
        pondCenterCoor = this.transform.position;

        PondRipplePS[] pss = this.GetComponentsInChildren<PondRipplePS>();

        pondRipplePhysicsPS = pss[0];
        pondRippleSpritePS = pss[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (gotPlayerTransform)
        {          
            if (isPlayerInRange())
            {
                this.transform.position = playerTransform.position;                

                if (isPaused)
                {
                    pondRipplePhysicsPS.setInRange(true);
                    pondRippleSpritePS.setInRange(true);

                    isPaused = false;
                }                
            }
            else
            {
                //ie out of range
                isPaused = true;

                pondRipplePhysicsPS.setInRange(false);
                pondRippleSpritePS.setInRange(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gotPlayerTransform == false && collision.GetComponent<PlayerUI>() != null)
        {
            Rigidbody2D playerRigidbody = collision.GetComponent<Rigidbody2D>();

            pondRipplePhysicsPS.setPlayerRB(playerRigidbody);
            pondRippleSpritePS.setPlayerRB(playerRigidbody);

            playerTransform = collision.transform;

            this.GetComponent<CircleCollider2D>().enabled = false;

            gotPlayerTransform = true;
        }
    }

    private bool isPlayerInRange()
    {
        float distanceFromCenter = ((Vector2) playerTransform.position - pondCenterCoor).magnitude;

        if(distanceFromCenter <= pondRadius)
        {
            return true;
        }
        else
        {
            return false;
        }       
    }
}
