using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * projectile collider goes where its SHADOW is
 * 
 * Physics.IgnoreCollision? 
 * projectile is destroyed upon a hit
 * 
 * animate destroy
 * 
 */

public class Projectile : MonoBehaviour
{
    //references
    private GameObject myProjectile;

    //fields
    private float height = 1.3f; //default height?

    private void Awake()
    {
        myProjectile = this.gameObject;

        this.gameObject.AddComponent<RoomObjectUI>().setHeight(this.height);  //!adds object component so that projectile gets sprite-sorted
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RoomObjectUI other = collision.gameObject.GetComponent<RoomObjectUI>();
        if (other != null)    //if collided thing has Object component, need to check if it's tall enough to collide
        {
            if(height < other.getHeight())
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
        //this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f); //to make the projectile freeze
        Destroy(myProjectile);
    }
}
