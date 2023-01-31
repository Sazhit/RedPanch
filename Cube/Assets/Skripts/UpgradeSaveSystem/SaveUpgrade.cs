using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveUpgrade : MonoBehaviour
{
    public static void SavePlayer(Upgrade upgrade)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataUpbgrade data = new DataUpbgrade(upgrade);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static DataUpbgrade LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.dat";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            DataUpbgrade data = formatter.Deserialize(stream) as DataUpbgrade;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
