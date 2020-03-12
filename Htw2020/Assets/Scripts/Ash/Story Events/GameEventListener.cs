using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Attach script to player for now 
 * 
 * sub-types of events: inventory-dependent, location-dependent, dialogue-dependent
 * 
 */

public class GameEventListener
{



    private void onFirstMeet()
    {
        Debug.Log("Meeting pk");
        GameEventManager.current.firstMeetTrigger();
    }

}
