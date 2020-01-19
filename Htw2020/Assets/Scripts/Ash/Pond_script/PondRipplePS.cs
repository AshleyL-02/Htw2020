using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * starts emitting when moving
 * 
 */

public class PondRipplePS : MonoBehaviour
{
    private bool gotPlayer = false;
    private bool inRange = false;

    //references
    public Rigidbody2D playerRB;
    private ParticleSystem myParticleSystem;

    private bool wasStopped = false;


    // Start is called before the first frame update
    private void Awake()
    {
        myParticleSystem = this.GetComponent<ParticleSystem>();
        myParticleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (gotPlayer && inRange)
        {
            if (playerRB.velocity == Vector2.zero)
            {
                myParticleSystem.Stop();
                wasStopped = true;
            }
            else
            {
                if (wasStopped == true)
                {
                    myParticleSystem.Play();
                    wasStopped = false;
                }

            }
        }
    }

    public void setPlayerRB(Rigidbody2D playerRB)
    {
        this.playerRB = playerRB;
        gotPlayer = true;
    }

    public void setInRange(bool inRange)
    {
        this.inRange = inRange;
    }


}
