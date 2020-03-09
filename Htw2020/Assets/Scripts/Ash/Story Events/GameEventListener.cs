using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Attach script to player for now 
 * 
 * 
 * 
 */

public class GameEventListener : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("start wait");
        StartCoroutine(waitToMeet());
    }

    private void Update()
    {
        
    }


    private IEnumerator waitToMeet()
    {
        Debug.Log("waiting...");
        yield return new WaitForSeconds(2.0f);
        Debug.Log("waiting...");
        yield return new WaitForSeconds(2.0f);

        onFirstMeet();
    }


    private void onFirstMeet()
    {
        Debug.Log("Meeting pk");
        GameEventManager.current.firstMeetTrigger();
    }
}
