using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SaveShips(SpaceShips ships)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ships.data";
       

        FileStream stream = new FileStream(path, FileMode.Create);

        ShipsData data = new ShipsData(ships);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ShipsData LoadShips()
    {
        string path = Application.persistentDataPath + "/ships.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ShipsData data = formatter.Deserialize(stream) as ShipsData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static void SaveProgression(Progression pro)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/progression.data";


        FileStream stream = new FileStream(path, FileMode.Create);

        ProgressionData data = new ProgressionData(pro);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static ProgressionData LoadProgression(Progression pro)
    {
        string path = Application.persistentDataPath + "/progression.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ProgressionData data = formatter.Deserialize(stream) as ProgressionData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
