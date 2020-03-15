using System;
using UnityEngine;

public class GameEventManager
{
    public static GameEventManager current;


    //CONSTRUCTOR
    public GameEventManager()
    {
        current = this;
        
    }

    //Controller event trigger method
    public event Action<InputController> onControllerChangeTrigger;
    public void onControllerChange(InputController nextController)
    {
        if(onControllerChangeTrigger != null)
        {
            onControllerChangeTrigger(nextController);
        }
    }


    //Event trigger methods

    public event Action<int> onRoomChangeTrigger;
    public void onRoomChange(int roomNumber)
    {
        if (onRoomChangeTrigger != null)
        {
            onRoomChangeTrigger(roomNumber);
        }
    }

    
}
