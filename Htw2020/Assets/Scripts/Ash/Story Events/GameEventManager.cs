using System;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action onFirstMeetTrigger;

    public void firstMeetTrigger()
    {
        if(onFirstMeetTrigger != null)
        {
            onFirstMeetTrigger();
        }
    }
}
