using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * Used as a base class for objects (that can be collided w/?)
 * 
 * 
 * create InteractableObject class?
 *
 * can player duck/sit to dodge projectiles?
 * 
 */

public class Object : MonoBehaviour
{
    [SerializeField]    //! temp
    private float height = 1.0f; //intended height in game space. Assumes object doesn't have holes


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getHeight()
    {
        return height;
    }
}
