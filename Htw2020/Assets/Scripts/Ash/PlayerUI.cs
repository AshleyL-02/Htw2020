using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Fix movement/input lag 
 * 
 * 
 * 
 */

public class PlayerUI : MonoBehaviour
{
    //Static variables
    private static readonly Vector2 START_COOR = new Vector2(0.0f, -1.0f);

    //Components and GO's
    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;

    //Movement/input-related fields (consider putting in player data class?)
    private static readonly float SPEED = 2.3f;
    private static readonly float SPRINT_MULTIPLIER = 1.8f;

    private float speedMultiplier = SPEED;




    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    
    void Start()
    {
        //t temp 1
        this.transform.position = START_COOR;


        //t temp 1

    }

    
    void Update()
    {
        readInput();


        //temp 2
        /*
        if (Input.GetButtonDown("Select"))
        {
            GameEvents_temp.current.InteractTrigger();
            Debug.Log("pressed select");
        }
        */
        //temp 2
    }
    private void FixedUpdate()
    {
        readMovementInput();
    }

    //ACCESSORs
    private Vector2 getPlayerDirection()    //normalized direction vector based on wasd input
    {
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementDirection.Normalize();

        return movementDirection;
    }

    //Mutators


    //PRIVATE METHODS


    //Input methods
    private void readInput()
    {
        readSprintInput();
        readSelectInput();
    }
    private void readMovementInput() //work on controls so the velocity is correct against walls
    {
        Vector2 movementDirection = getPlayerDirection();
        float movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f); //not sure how necessary this is for keyboard controls

        myRigidbody.velocity = movementDirection * movementSpeed * speedMultiplier;
    }
    
    private void readSprintInput()
    {
        if (Input.GetButton("Sprint"))  //use event trigger. change it asap
        {
            speedMultiplier = SPEED * SPRINT_MULTIPLIER;
        }
        else
        {
            speedMultiplier = SPEED;
        }
    }
    private void readSelectInput()
    {

        if (Input.GetButtonDown("Select"))
        {
            // checking if theres something to interact with

            // raycast for a gameobject (//! add layer filter?)

            Debug.DrawLine((Vector2)this.transform.position, (Vector2)this.transform.position + getPlayerDirection(), Color.red, 1.0f);

            RaycastHit2D interactRay = Physics2D.Raycast((Vector2)this.transform.position, getPlayerDirection(), 1.0f);//change to arrow direction

            if(interactRay.collider != null)
            {
                Debug.Log(interactRay.collider.ToString());
            }
        }
    }
}
