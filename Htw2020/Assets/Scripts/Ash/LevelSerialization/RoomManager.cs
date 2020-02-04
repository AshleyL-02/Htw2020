using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private void Awake()
    {
        saveFloor();
    }
    private void loadFloor()
    {

    }
    private void saveFloor()
    {
        GameObject[] rooms = findRooms();
    }

    private GameObject[] findRooms()
    {
        Grid[] grids = this.GetComponentsInChildren<Grid>();
        GameObject[] rooms = new GameObject[grids.Length];

        for (int i = 0; i < grids.Length; i++)
        {
            rooms[i] = grids[i].gameObject;
        }

        return rooms;
    }
}
