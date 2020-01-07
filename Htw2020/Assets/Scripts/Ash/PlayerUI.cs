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
    private static readonly float SPEED = 4.8f;
    private static readonly float SPRINT_MULTIPLIER = 1.8f;


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //temp 1
        this.transform.position = START_COOR;


        //temp 1

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
