using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SavePlayer (PlayerDataScript playerDataScript, int saveNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter ();
        string path = Application.persistentDataPath + ("/PlayerSave{0}.txt", saveNumber);
        FileStream stream = new FileStream(path,FileMode.Create);

        DataSave dataSave = new DataSave(playerDataScript); 

        formatter.Serialize(stream, dataSave);
        stream.Close();

    }

    public static DataSave LoadPlayer(int saveNumber)
    {
        string path = Application.persistentDataPath + ("/PlayerSave{0}.txt", saveNumber);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DataSave dataSave = formatter.Deserialize(stream) as DataSave;
            stream.Close();

            return dataSave;
        }
        else
        {
            Debug.LogError("Save file not found in "+path);
            return null;
        }
    }
    
}
