﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * attach to player
 * 
 * "cardinalizing" movement direction will be unnecessary if sprite (art) can face 8 directions
 * 
 */

public class PlayerController : MonoBehaviour, IReadsInput
{

    //static fields (consider putting in player data class?)
    private static readonly float SPEED = 2.4f;
    private static readonly float SPRINT_MULTIPLIER = 2.5f;

    //fields
    private float speedMultiplier = SPEED;
    private Vector2 lastFacingDirection = Vector2.down;

    // references
    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;
    private Animator myAnimator;
    private ProjectileInstantiator myPI;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        myPI = GetComponent<ProjectileInstantiator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }



    //ACCESSORS
    private Vector2 getInputMovementDirection()    //normalized direction vector based on wasd input //! consider setting a private variable for this value
    {
        //change to getAxis for joystick compatibility
        Vector2 movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementDirection.Normalize();

        return movementDirection;
    }

    //PRIVATE METHODS
    private Vector2 cardinalizeVector(Vector2 movementDirection)    //turn vector into an up, down, left, or right vector
    {
        Vector2 cardinal = Vector2.down;
        if (movementDirection == Vector2.zero)
        {
            Debug.LogError("incorrect vector");
            return cardinal;
        }
        else if (movementDirection.y > 0.4)
        {
            cardinal = Vector2.up;
        }
        else if (movementDirection.y < -0.4)
        {
            cardinal = Vector2.down;
        }
        else if (movementDirection.x > 0)
        {
            cardinal = Vector2.right;
        }
        else if (movementDirection.x < 0)
        {
            cardinal = Vector2.left;
        }
        return cardinal;
    }

    private void setMovementAnimation()
    {
        Vector2 movementDirection = getInputMovementDirection();
        if (movementDirection != Vector2.zero)
        {
            myAnimator.SetFloat("Horizontal", movementDirection.x);
            myAnimator.SetFloat("Vertical", movementDirection.y);
        }
        myAnimator.SetFloat("Speed", movementDirection.magnitude * speedMultiplier / SPEED);  //dumb math trick. change to check if sprinting if you have time

    }

    //Input methods

    public void readInput()
    {
        readSprintInput();
        readSelectInput();
        readInventoryOpenInput();

        readShootInput();

        setMovementAnimation();

        readMovementInput();
    }
    private void readMovementInput() //work on controls so the velocity is correct against walls
    {
        Vector2 movementDirection = getInputMovementDirection();
        float movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f); //not sure how necessary this is for keyboard controls

        myRigidbody.velocity = movementDirection * movementSpeed * speedMultiplier;

        if (movementDirection != Vector2.zero)   //set lastDirection
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
            if (getInputMovementDirection() == Vector2.zero) //vector must be cardinalized if player is idle
            {
                facingDirection = cardinalizeVector(facingDirection);
            }

            // raycast in facing direction. note myCollider.offset.y because the ray needs to start "between the feet"
            Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y + myCollider.offset.y), new Vector2(this.transform.position.x, this.transform.position.y + myCollider.offset.y) + facingDirection, Color.red, 1.0f);
            RaycastHit2D interactRay = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y + myCollider.offset.y), facingDirection, 1.0f);//change to arrow direction


            if (interactRay.collider != null)
            {
                // tells other object to execute interact
                IInteractable interactTarget = interactRay.collider.GetComponent<IInteractable>();
                if (interactTarget != null)
                {
                    interactTarget.interact();
                }
            }

        }
    }
    private void readInventoryOpenInput()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            GameEventManager.current.onControllerChange(InputController.INVENTORY);
        }
    }

    private void readShootInput()
    {
        //! TEMPORARY
        if (Input.GetButtonDown("AttackTemp"))
        {
            myPI.shootProjectile(lastFacingDirection, this.transform.position, 0.5f, 5.0f);
        }

    }
}
