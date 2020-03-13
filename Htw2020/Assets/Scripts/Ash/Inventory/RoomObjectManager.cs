using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

/*
 * Instantiates Room Objects based on room object map
 * 
 * GameObject go = (GameObject)Instantiate(Resources.Load("MyPrefab")); 
 * Implement hash table
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
    

    private Sprite[] spriteDirectory;
    

    private string[,] testRoomObjectMap = new string[TESTROOM_WIDTH, TESTROOM_HEIGHT];


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

        overwriteRoomObjectDirectory(temp);
        */
        loadAllDirectories();
        

        //set items in map
        testRoomObjectMap[0, 0] = "Apple";
        testRoomObjectMap[0, TESTROOM_HEIGHT -1] = "Red Robe";
        testRoomObjectMap[TESTROOM_WIDTH -1, 0] = "Stone Stairs";
        testRoomObjectMap[TESTROOM_WIDTH -1, TESTROOM_HEIGHT -1] = "Boots";
        testRoomObjectMap[1, 1] = "Key";

        //load objects
        loadRoomObjectsInTestRoom();

    }

    // ACCESSORS
    private Sprite getSpriteFromDirectory(string spriteName)
    {
        if(spriteDirectory != null)
        {
            foreach(Sprite sprite in spriteDirectory)
            {
                if (sprite.name.Equals(spriteName))
                {
                    return sprite;
                }
            }
            Debug.LogError("Could not find corresponding sprite");
        }
        else
        {
            Debug.LogError("Sprite directory is null; couldn't find sprite");
        }

        return null;
    }

    private RoomObject getRoomObjectFromDirectory(string roomObjectName)
    {
        foreach(RoomObject roomObject in roomObjectDirectory)
        {
            if (roomObject.name.Equals(roomObjectName))
            {
                return roomObject;
            }
        }
        Debug.LogError("Couldn't find Room Object in directory: " + roomObjectName);
        return null;
    }

    private void instantiateRoomObjectGameObject(string name, Vector2 position)
    {
        GameObject roomObjectGameObject = new GameObject(name);
        RoomObject roomObject = getRoomObjectFromDirectory(name);

        RoomObjectUI roomObjectUI = roomObjectGameObject.AddComponent<RoomObjectUI>();

        roomObjectUI.setupRoomObjectGameObject(roomObjectGameObject, roomObject);

        roomObjectGameObject.transform.position = position;
    }


    //METHODS
    
    private void loadRoomObjectsInTestRoom()
    {
        //cycle through each point in roomobject map
        for (int x = 0; x < testRoomObjectMap.GetLength(0); x++)
        {
            for (int y = 0; y < testRoomObjectMap.GetLength(1); y++)
            {
                string roomObjectName = testRoomObjectMap[x, y];

                 if (roomObjectName != null)   //if valid object #
                {                  
                    Vector3 position = calculatePositionFromGrid(x, y);
                    instantiateRoomObjectGameObject(roomObjectName, position);
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
    private void loadAllDirectories()
    {
        loadSpriteDirectory();
        loadRoomObjectDirectory();
        addSpritesToRoomObjectDirectory();
    }
    private void loadSpriteDirectory()
    {
        spriteDirectory = Resources.LoadAll<Sprite>(SPRITE_DIRECTORY_RESOURCES_PATH);
    }
    
    private void addSpritesToRoomObjectDirectory()
    {
        foreach (RoomObject roomObject in roomObjectDirectory)
        {
            roomObject.setSprite(getSpriteFromDirectory(roomObject.name));
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
    private void overwriteRoomObjectDirectory(List<RoomObject> newRoomObjectDirectory)
    {
        Type t = newRoomObjectDirectory.GetType();
        XmlSerializer serz = new XmlSerializer(t);
        StreamWriter writer = new StreamWriter(ROOMOBJECT_DIRECTORY_PATH, false);    //overwrites file or creates a new one

        serz.Serialize(writer, newRoomObjectDirectory);

        writer.Close();
    }


}
