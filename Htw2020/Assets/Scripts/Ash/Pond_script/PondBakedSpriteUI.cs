using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondBakedSpriteUI : MonoBehaviour
{
    //references
    public Rigidbody2D playerRB;
    public ParticleSystem myParticleSystem;

    private bool wasStopped = false;
    

    // Start is called before the first frame update
    void Start()
    {
        //myRigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRB.velocity == Vector2.zero)
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
