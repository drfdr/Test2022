using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad {
    public static void SaveData(PlayerData PD,SeedBox SB,SavableGOS SGOS) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = System.Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Saved Games\\") + "TestGame.save";

        FileStream stream = new FileStream(path, FileMode.Create);

        SaveSerializable SaveSerializableX = new SaveSerializable(PD,SB,SGOS);


        formatter.Serialize(stream, SaveSerializableX);
        stream.Close();
        Debug.Log("Game Saved");
    }

    public static SaveSerializable LoadData() {
        string path = System.Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Saved Games\\") + "TestGame.save";

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveSerializable data = formatter.Deserialize(stream) as SaveSerializable;

            stream.Close();
            Debug.Log("Game Load");

            return data;
        } else {
            Debug.LogError("Error: Save file not found in " + path);
            return null;
        }
    }
}