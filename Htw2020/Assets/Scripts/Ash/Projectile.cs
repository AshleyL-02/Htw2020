using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * projectile collider goes where its SHADOW is
 * 
 * animate destroy
 * 
 */

public class Projectile : MonoBehaviour
{
    //references
    private GameObject myProjectile;

    //fields
    private float height = 1.5f; //default height?

    private void Awake()
    {
        myProjectile = this.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Object other = collision.gameObject.GetComponent<Object>();
        if (!other.Equals(null))    //if collided thing has Object component, need to check if it's tall enough to collide
        {
            if(height > other.getHeight())
            {
                destroyProjectile();
            }
        }
        else
        {
            destroyProjectile();
        }
        
    }


    public void destroyProjectile()
    {
        Destroy(myProjectile);
    }
}
