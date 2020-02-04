using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//Application.persistentDataPath + "/saves"
public class RoomSerializer
{
    private static readonly string floorFolderPath = "Assets/Scripts/Ash/LevelSerialization";
    public static bool SaveFloorData(string floorName, RoomInfo[] myRooms)
    {
        BinaryFormatter formatter = GetBinaryFormatter();

        if (!Directory.Exists(floorFolderPath))
        {
            Directory.CreateDirectory(floorFolderPath);

        }

        string path = floorFolderPath + "/" + floorName + ".floor";
        FileStream file = File.Create(path);
        formatter.Serialize(file, myRooms);

        file.Close();

        return true;
    }

    private static object LoadFloorData(string floorName)
    {
        string filePath = floorFolderPath + "/" + floorName + ".floor";
        if (!File.Exists(filePath))
        {
            Debug.LogError("Can't load file");
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();

        FileStream file = File.Open(filePath, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            Debug.Log(save.GetType());
            return save;
        }

        catch //in case if wrong path is passed
        {
            Debug.LogErrorFormat("Failed to load file at {0}", filePath);
            file.Close();
            return null;
        }
    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        return formatter;
    }

}
