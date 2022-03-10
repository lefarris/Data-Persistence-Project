using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public string playerName;
    public int highScore;
    public string highScoreName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            LoadData();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    public void StoreData()
    {
        SaveData data = new SaveData();

        data.highScore = highScore;
        data.highScoreName = highScoreName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/data.json", json);
    }

    public void LoadData()
    {
        if(File.Exists(Application.persistentDataPath + "/data.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/data.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }

}
