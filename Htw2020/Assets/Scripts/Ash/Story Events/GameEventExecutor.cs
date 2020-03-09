using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventExecutor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.current.onFirstMeetTrigger += onFirstMeetEvent;

    }

    private void onFirstMeetEvent()
    {
        Debug.Log("pk gives you bubbles");
        
    }


}
