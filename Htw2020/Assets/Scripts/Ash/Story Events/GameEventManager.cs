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
