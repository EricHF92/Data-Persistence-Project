using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Handles data persistency
/// </summary>
public class GameManager : MonoBehaviour
{
    // Stores an instance of main manager script
    public static GameManager Instance;

    // Stored data
    public string Name;
    public int HighScore;

    // Checks for other instances of game manager and creates one
    private void Awake()
    {
        // Singleton
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Game manager initialization
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Save load feature
    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int HighScore;
    }

    /// <summary>
    /// Saves name of high score
    /// </summary>
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.Name = Name;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    /// <summary>
    /// Saves highscore
    /// </summary>
    public void SaveHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
            HighScore = data.HighScore;
        }
    }
}
