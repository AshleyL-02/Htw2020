using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObject //change this or roomobjectui to scriptable object?
{


    //fields
    protected Sprite mySprite;


    //protected GameObject myGameObject;

    // things to serialize
    public string name;
    public string description;


    public RoomObject() { }
    public void setupRoomObject(string name, string description)
    {
        this.name = name;
        this.description = description;
    }
    public void setupRoomObject(RoomObject other)
    {
        this.name = other.getName();
        this.description = other.getDescription();          
    }


    //ACCESSORS
    public string getName()
    {
        return name;
    }
    public string getDescription()
    {
        return description;
    }



}
