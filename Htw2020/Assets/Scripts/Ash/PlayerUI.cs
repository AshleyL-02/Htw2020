using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * "cardinalizing" movement direction will be unnecessary if sprite can face 8 directions
 * 
 * 
 */



public class PlayerUI : MonoBehaviour
{
    //Static variables
    private static readonly Vector2 START_COOR = new Vector2(0.0f, -1.0f);

    //References
    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;
    private Animator myAnimator;

    //Movement/input-related fields (consider putting in player data class?)
    private static readonly float SPEED = 1.8f;
    private static readonly float SPRINT_MULTIPLIER = 2.0f;

    private float speedMultiplier = SPEED;
    private Direction lastFacingDirection_old = Direction.DOWN;
    private Vector2 lastFacingDirection = Vector2.down;
        


    private enum Direction
    {
        UP,
        RIGHT,
        DOWN,
        LEFT
    }

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
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
        setMovementAnimation();

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
    private Vector2 getInputMovementDirection()    //normalized direction vector based on wasd input //! consider setting a private variable for this value
    {
        //change to getAxis for joystick compatibility
        Vector2 movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementDirection.Normalize();

        return movementDirection;
    }
    private Vector2 cardinalizeVector(Vector2 movementDirection)    //turn vector into an up, down, left, or right vector
    {
        Vector2 cardinal = Vector2.down;
        if(movementDirection == Vector2.zero)
        {
            Debug.LogError("incorrect vector");
            return cardinal;         
        }
        else if(movementDirection.y > 0.4)
        {
            cardinal = Vector2.up;
        }
        else if(movementDirection.y < -0.4)
        {
            cardinal = Vector2.down;
        }
        else if(movementDirection.x > 0)
        {
            cardinal = Vector2.right;
        }
        else if(movementDirection.x < 0)
        {
            cardinal = Vector2.left;
        }
        return cardinal;
    }

    //Mutators


    //PRIVATE METHODS
    private void setMovementAnimation()
    {
        Vector2 movementDirection = getInputMovementDirection();
        if(movementDirection != Vector2.zero)
        {
            myAnimator.SetFloat("Horizontal", movementDirection.x);
            myAnimator.SetFloat("Vertical", movementDirection.y);
        }       
        myAnimator.SetFloat("Speed", movementDirection.magnitude * speedMultiplier/SPEED);  //dumb math trick. change to check if sprinting if you have time
        
    }

    //Input methods
    private void readInput()
    {
        readSprintInput();
        readSelectInput();
    }
    private void readMovementInput() //work on controls so the velocity is correct against walls
    {
        Vector2 movementDirection = getInputMovementDirection();
        float movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f); //not sure how necessary this is for keyboard controls

        myRigidbody.velocity = movementDirection * movementSpeed * speedMultiplier;

        if(movementDirection != Vector2.zero)   //set lastDirection
        {
            lastFacingDirection = new Vector2(movementDirection.x, movementDirection.y);
        }    
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

            //getting player's facing direction
            Vector2 facingDirection = lastFacingDirection;   //already normalized
            if(getInputMovementDirection() == Vector2.zero) //vector must be cardinalized if player is idle
            {
                facingDirection = cardinalizeVector(facingDirection);
            }

            // raycast in facing direction
            Debug.DrawLine((Vector2)this.transform.position, (Vector2)this.transform.position + facingDirection, Color.red, 1.0f);
            RaycastHit2D interactRay = Physics2D.Raycast((Vector2)this.transform.position, facingDirection, 1.0f);//change to arrow direction

            if(interactRay.collider != null)
            {
                Debug.Log(interactRay.collider.ToString());
            }

        }
    }
}
