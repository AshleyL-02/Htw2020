using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerUI : MonoBehaviour
{
    //Static fields
    private static readonly Vector2 START_COOR = new Vector2(0.0f, 1.0f);

    

    //References


    //other fields
    private PlayerData myPlayerData = new PlayerData();


    //Field End

    private void Awake()
    {
        
    }

    
    void Start()
    {
        //t temp 1
        //this.transform.position = START_COOR;
        //t temp 1



        //TESTING EVENTS HERE

        //Debug.Log("start event test");
        //StartCoroutine(testOnEventMethod());

        //ENDS HERE

    }

    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! WATCH OUTTTT
    private IEnumerator testOnEventMethod()
    {
        Debug.Log("waiting to test...");
        yield return new WaitForSeconds(2.0f);

        Debug.Log("Entered room 0");
        myPlayerData.setCurrentRoomNumber(0);

        yield return new WaitForSeconds(2.0f);

        Debug.Log("Entered room 1");
        myPlayerData.setCurrentRoomNumber(1);

        yield return new WaitForSeconds(2.0f);

        Debug.Log("Entered room 2");
        myPlayerData.setCurrentRoomNumber(2);

        yield return new WaitForSeconds(2.0f);

        Debug.Log("Entered room 3");
        myPlayerData.setCurrentRoomNumber(3);

        Debug.Log("ended event test");

    }


    void Update()
    {

    }
    private void FixedUpdate()
    {
        
        
    }

    //ACCESSORs
    

    
    //MUTATORS
    

    //PRIVATE METHODS
    

    
}
