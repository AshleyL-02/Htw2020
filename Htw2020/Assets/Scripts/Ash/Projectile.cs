using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * projectile collider goes where its SHADOW is
 * 
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
    private float height = 1.5f; //default height?

    private void Awake()
    {
        myProjectile = this.gameObject;

        this.gameObject.AddComponent<Object>().setHeight(this.height);  //!adds object component so that projectile gets sprite-sorted
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
        Object other = collision.gameObject.GetComponent<Object>();
        if (other != null)    //if collided thing has Object component, need to check if it's tall enough to collide
        {
            if(height < other.getHeight())
            {
                destroyProjectile();
                Debug.Log("hit an object that was too tall");
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
