using System;
using UnityEngine;

/*
 * Instantiates Room Objects based on room object map
 * 
 * GameObject go = (GameObject)Instantiate(Resources.Load("MyPrefab")); 
 * 
 * 
 */
public class RoomObjectManager : MonoBehaviour
{
    //static fields
    private static readonly Vector2 TESTROOM_GRID_LOWER_LEFT_COOR = new Vector2(-10.5f, -11.5f);    //coor starts at center of tile
    private static readonly int TESTROOM_WIDTH = 21;
    private static readonly int TESTROOM_HEIGHT = 3;

    //statid fields for object defaults

    //fields

    [SerializeField]
    private GameObject[] roomObjectPrefabDirectory;

    private int[,] testRoomObjectMap = new int[TESTROOM_WIDTH, TESTROOM_HEIGHT];


    private void Awake()
    {
        //cycle through each point in roomobject map
        for (int w = 0; w < testRoomObjectMap.GetLength(0); w++)
        {
            for (int h = 0; h < testRoomObjectMap.GetLength(1); h++)
            {
                testRoomObjectMap[w, h] = -1;
            }
        }

        testRoomObjectMap[0, 0] = 0;
        testRoomObjectMap[0, TESTROOM_HEIGHT -1] = 1;
        testRoomObjectMap[TESTROOM_WIDTH -1, 0] = 2;
        testRoomObjectMap[TESTROOM_WIDTH -1, TESTROOM_HEIGHT -1] = 3;
        testRoomObjectMap[1, 1] = 4;

        loadRoomObjectsInTestRoom();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //METHODS
    
    private void loadRoomObjectsInTestRoom()
    {
        //cycle through each point in roomobject map
        for (int x = 0; x < testRoomObjectMap.GetLength(0); x++)
        {
            for (int y = 0; y < testRoomObjectMap.GetLength(1); y++)
            {
                int directoryIndex = testRoomObjectMap[x, y];

                 if (directoryIndex >= 0)   //if valid object #
                {                                 
                    if(directoryIndex < roomObjectPrefabDirectory.Length)
                    {
                        GameObject roomObjectPrefab = roomObjectPrefabDirectory[directoryIndex];
                        Vector3 roomObjectPosition = calculatePositionFromGrid(x, y);

                        RoomObjectUI.instantiateRoomObjectWithDefaults(roomObjectPrefab, roomObjectPosition);
                    }
                    else
                    {
                        Debug.Log("Couldn't find RoomObject at index: " + directoryIndex);
                    }                
                }
            }
        }
    }

    private Vector3 calculatePositionFromGrid(int xByGrid, int yByGrid)
    {
        Vector3 position;
        float x = TESTROOM_GRID_LOWER_LEFT_COOR.x + xByGrid;
        float y = TESTROOM_GRID_LOWER_LEFT_COOR.y + yByGrid;

        position = new Vector3(x, y, 0f);

        return position;
    }

}
