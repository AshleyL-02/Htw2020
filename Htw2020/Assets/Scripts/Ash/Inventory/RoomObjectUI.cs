using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * MUST SET HEIGHT!!!!!
 * 
 * includes sprite sorting
 * 
 * for anything with a physical representation that gets put into a room (includes player, zombies, items, furniture, arms)
 * 
 * 
 * can player duck/sit to dodge projectiles?
 * consider setting tag to "Object" for easier detection (instead of using getComponent)
 * 
 */

public class RoomObjectUI : MonoBehaviour, IInteractable
{

    //static fields
    public static readonly string MAIN_SORTING_LAYER_NAME = "Main";    //i.e. the sorting layer where sorted objects are
    public static readonly float DEFAULT_COLLIDER_SIZE = 0.5f;
    public static readonly float DEFAULT_HEIGHT = 1.0f;

    //Fields
    private RoomObject myRoomObject = new RoomObject();


    [SerializeField]    //! temp
    private float height = DEFAULT_HEIGHT; //intended height in game space. Assumes object doesn't have holes


    private bool isMoveable = true;   // defaults to true

    //field end

    private void Awake()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>() != null)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = MAIN_SORTING_LAYER_NAME;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        setZPosition(); //this is the only time it gets called for non-moving objects
    }

    // Update is called once per frame
    void LateUpdate()
    {
        updateZPosition();
    }
    // ACCESSORS 
    public float getHeight()
    {
        return height;
    }


    // MUTATORS
    public void setHeight(float height)
    {
        this.height = height;
    }

    // IInteractable methods
    public void interact()
    {
        Debug.Log(myRoomObject.getDescription());
    }

    // METHODS
    public void setupRoomObjectGameObject(GameObject roomObjectGameObject, RoomObject roomObject)  //adds default components to room object
    {
        this.myRoomObject.setupRoomObject(roomObject);

        if(roomObjectGameObject.GetComponent<SpriteRenderer>() == null)
        {
            roomObjectGameObject.AddComponent<SpriteRenderer>().sprite = roomObject.getSprite();
            this.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = MAIN_SORTING_LAYER_NAME;
        }

        if (roomObjectGameObject.GetComponent<Collider2D>() == null)
        {
            BoxCollider2D collider = roomObjectGameObject.AddComponent<BoxCollider2D>();
            collider.size = new Vector2(DEFAULT_COLLIDER_SIZE, DEFAULT_COLLIDER_SIZE);
            collider.offset = new Vector2(0f, DEFAULT_COLLIDER_SIZE / 2f);
        }
    }

    private void updateZPosition()   //sets z value of the GameObject (to "isometrically sort" it)
    {
        if (isMoveable)
        {
            setZPosition();
        }
    }
    private void setZPosition()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.y);
    }
}
