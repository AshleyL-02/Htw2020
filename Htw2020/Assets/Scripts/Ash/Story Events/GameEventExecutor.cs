using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * look up singletons 
 * 
 * THIS CLASS IS TEMPORARY!!!!!!!!!!
 * Any class that needs to subscribe to events will have a global object (PagerEventExecutor, for e.g.); that inherits GameEventExecutor?
 * 
 * remember to unsubscribe events
 * 
 * Use coroutines or threading for multi-event story sequences?
 * 
 * think up a sample story with a few events and execute that to practice
 * 
 * sub-types of events: inventory-dependent, location-dependent, dialogue-dependent
 * 
 */

public class GameEventExecutor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.current.onRoomChangeTrigger += onRoomChangeEventSendPagerMessage;


    }


    private void onRoomChangeEventSendPagerMessage(int roomNumber)
    {
        if(roomNumber == 1)
        {
            Debug.Log("whoa, it's room 1");
        }
        else if(roomNumber == 2)
        {
            Debug.Log("room 2, huh?");
        }
    }


}
