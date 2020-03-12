﻿using System.Collections;
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
 */

public class GameEventExecutor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.current.onFirstMeetTrigger += onFirstMeetEvent;

        GameEventManager.current.onRoomChangeTrigger += onRoomChangeEventSendPagerMessage;


    }

    private void onFirstMeetEvent()
    {
        Debug.Log("pk gives you bubbles");
        
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