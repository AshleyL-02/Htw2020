using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{

    private GameEventManager myGameEventManager = new GameEventManager();

    //Location-related fields
    private int currentRoomNumber;

    //CONSTRUCTOR
    public PlayerData()
    {

    }

    //MUTATORS
    public void setCurrentRoomNumber(int roomNumber)
    {
        this.currentRoomNumber = roomNumber;

        myGameEventManager.onRoomChange(roomNumber);
    }





}
