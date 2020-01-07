using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    //Static variables
    private static readonly Vector2 START_COOR = new Vector2(0.0f, -1.0f);

    //Components and GO's
    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;

    //Movement/input-related fields (consider putting in player data class?)
    private static readonly float SPEED = 3.8f;
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
    }
    private void FixedUpdate()
    {
        readMovementInput();
    }


    //PRIVATE METHODS


    //Input methods
    private void readInput()
    {
        readSprintInput();
    }
    private void readMovementInput() //work on controls so the velocity is correct against walls
    {
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); 
        float movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f); //not sure how necessary this is for keyboard controls
        movementDirection.Normalize();

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
}
