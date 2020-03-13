using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

/*
 * Instantiates Room Objects based on room object map
 * 
 * GameObject go = (GameObject)Instantiate(Resources.Load("MyPrefab")); 
 * Sprite.Create()
 * 
 */
public class RoomObjectManager : MonoBehaviour
{
    //Serialization-related fields
    private static readonly string ROOMOBJECT_DIRECTORY_PATH = "Assets/Scripts/Ash/Resources/RoomObjectDirectory.xml";
    private static readonly string SPRITE_DIRECTORY_RESOURCES_PATH = "SpriteDirectory";

    [System.Xml.Serialization.XmlArray]
    private static List<RoomObject> roomObjectDirectory = new List<RoomObject>();

    //static fields
    private static readonly Vector2 TESTROOM_GRID_LOWER_LEFT_COOR = new Vector2(-10.5f, -11.5f);    //coor starts at center of tile
    private static readonly int TESTROOM_WIDTH = 21;
    private static readonly int TESTROOM_HEIGHT = 3;

    //statid fields for object defaults

    //fields
    private List<GameObject> roomObjectGameObjectDirectory = new List<GameObject>();

    private Sprite[] spriteDirectory;
    

    private int[,] testRoomObjectMap = new int[TESTROOM_WIDTH, TESTROOM_HEIGHT];


    private void Awake()
    {
        //make some test roomObjects
        /*
        List<RoomObject> temp = new List<RoomObject>();
        temp.Add(new RoomObject());
        temp[0].setupRoomObject("Apple", "It's an apple");

        temp.Add(new RoomObject());
        temp[1].setupRoomObject("Boots", "They're dirty and old and smell like vomit");

        temp.Add(new RoomObject());
        temp[2].setupRoomObject("Key", "There's a morse code chart carved into its backside");

        temp.Add(new RoomObject());
        temp[3].setupRoomObject("Red Robe", "Luxurious.");

        temp.Add(new RoomObject());
        temp[4].setupRoomObject("Stone Stairs", "You could sit on these.");

        overwriteRoomObjectPrefabDirectory(temp);
        */

        //load sprites
        loadSpriteDirectory();
        loadRoomObjectDirectory();
        loadRoomObjectGameObjectDirectory();

        //set items in map
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

        //load objects
        loadRoomObjectsInTestRoom();

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
                    if(directoryIndex < roomObjectGameObjectDirectory.Count)
                    {
                        GameObject roomObjectGameObject = roomObjectGameObjectDirectory[directoryIndex];
                        Vector3 position = calculatePositionFromGrid(x, y);

                        Instantiate(roomObjectGameObject, position, Quaternion.identity).SetActive(true);
                        
                    }
                    else
                    {
                        Debug.Log("Couldn't find RoomObjectGameObject at index: " + directoryIndex);
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

    //SERIALIZATION METHODS
    private void loadSpriteDirectory()
    {
        spriteDirectory = Resources.LoadAll<Sprite>(SPRITE_DIRECTORY_RESOURCES_PATH);
    }
    private void loadRoomObjectGameObjectDirectory()
    {

        foreach(Sprite sprite in spriteDirectory)
        {
            string name = sprite.name;
            GameObject roomObjectGameObject = new GameObject(name);

            roomObjectGameObject.AddComponent<SpriteRenderer>().sprite = sprite;

            bool foundCorrespondingRoomObject = false;

            //look for room object with same name
            foreach(RoomObject roomObject in roomObjectDirectory)
            {
                if (roomObject.getName().Equals(name))
                {                   
                    RoomObjectUI roomObjectUI = roomObjectGameObject.AddComponent<RoomObjectUI>();

                    roomObjectUI.setupGameObjectWithDefaults(roomObjectGameObject, roomObject);

                    foundCorrespondingRoomObject = true;

                    break;
                }
            }
            if(foundCorrespondingRoomObject == false)
            {
                Debug.Log("Couldn't find serialized room object for sprite: " + name);
            }

            roomObjectGameObject.SetActive(false);
            roomObjectGameObjectDirectory.Add(roomObjectGameObject);
        }
    }

    private void loadRoomObjectDirectory()
    {
        if (File.Exists(ROOMOBJECT_DIRECTORY_PATH))
        {
            Type t = roomObjectDirectory.GetType();
            XmlSerializer serz = new XmlSerializer(t);
            StreamReader reader = new StreamReader(ROOMOBJECT_DIRECTORY_PATH);
            roomObjectDirectory = (List<RoomObject>)serz.Deserialize(reader);
            reader.Close();
        }
    }
    private void overwriteRoomObjectPrefabDirectory(List<RoomObject> newRoomObjectDirectory)
    {

        Type t = newRoomObjectDirectory.GetType();
        XmlSerializer serz = new XmlSerializer(t);
        StreamWriter writer = new StreamWriter(ROOMOBJECT_DIRECTORY_PATH, false);    //overwrites file or creates a new one

        serz.Serialize(writer, newRoomObjectDirectory);

        writer.Close();
    }


}
