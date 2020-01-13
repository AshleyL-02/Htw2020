using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * MUST SET HEIGHT!!!!!
 * 
 * 
 * Used as a base class for objects (that can be collided w/?)
 * 
 * INCLUDES SPRITE SORTING
 * 
 * create InteractableObject class?
 * can player duck/sit to dodge projectiles?
 * consider setting tag to "Object" for easier detection (instead of using getComponent)
 * 
 */

public class Object : MonoBehaviour
{
    //static variables
    private static readonly string MAIN_SORTING_LAYER_NAME = "Main";    //i.e. the sorting layer where sorted objects are

    //other variables
    [SerializeField]    //! temp
    private float height = 1.0f; //intended height in game space. Assumes object doesn't have holes

    private bool isMoving = true;   // defaults to true

    private void Awake()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = MAIN_SORTING_LAYER_NAME;  //a precaution, if not set in the inspector
    }
    // Start is called before the first frame update
    void Start()
    {
        setZPosition(); //this is the only time it gets called for non-moving objects
    }

    // Update is called once per frame
    void Update()
    {
        updateZPosition();
    }
    //ACCESSORS 
    public float getHeight()
    {
        return height;
    }

    //MUTATORS
    public void setHeight(float height)
    {
        this.height = height;
    }

    //Methods

    private void updateZPosition()   //sets z value of the GameObject (to "isometrically sort" it)
    {
        if (isMoving)
        {
            setZPosition();
        }
    }
    private void setZPosition()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.y);
    }
}
