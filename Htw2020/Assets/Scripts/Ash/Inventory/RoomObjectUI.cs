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

public class RoomObjectUI : MonoBehaviour
{
    //other variables
    [SerializeField]    //! temp
    private float height = RoomObject.DEFAULT_HEIGHT; //intended height in game space. Assumes object doesn't have holes

    private bool isMoveable = true;   // defaults to true

    //field end

    private void Awake()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = RoomObject.MAIN_SORTING_LAYER_NAME;
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
    public static void instantiateRoomObjectWithDefaults(GameObject roomObjectPrefab, Vector3 position) // instantiates gameobject with default settings
    {
        GameObject roomObjectClone = Instantiate(roomObjectPrefab, position, Quaternion.identity);

        setupRoomObjectDefaults(roomObjectClone);
    }
    private static void setupRoomObjectDefaults(GameObject roomObject)  //adds default components to room object
    {
        if(roomObject.GetComponent<RoomObjectUI>() == null)
        {
            roomObject.AddComponent<RoomObjectUI>();
        }

        if (roomObject.GetComponent<Collider2D>() == null)
        {
            BoxCollider2D collider = roomObject.AddComponent<BoxCollider2D>();
            collider.size = new Vector2(RoomObject.DEFAULT_COLLIDER_SIZE, RoomObject.DEFAULT_COLLIDER_SIZE);
            collider.offset = new Vector2(0f, RoomObject.DEFAULT_COLLIDER_SIZE / 2f);
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
