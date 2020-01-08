using System;
using UnityEngine;

// rename everything in this for clarity

public class GameEvents_temp : MonoBehaviour
{
    public static GameEvents_temp current;

    private void Awake()
    {
        current = this;
    }


    public event Action onInteractTrigger;
    public void InteractTrigger()
    {
        if (onInteractTrigger != null)
        {
            onInteractTrigger();
        }

    }

}
