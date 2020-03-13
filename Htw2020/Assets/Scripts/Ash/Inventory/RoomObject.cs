using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObject
{
    //static fields
    public static readonly string MAIN_SORTING_LAYER_NAME = "Main";    //i.e. the sorting layer where sorted objects are
    public static readonly float DEFAULT_COLLIDER_SIZE = 0.4f;
    public static readonly float DEFAULT_HEIGHT = 1.0f;

    //fields
    protected GameObject myGameObject;
}
