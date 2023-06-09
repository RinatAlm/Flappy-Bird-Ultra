using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static Level instance;
    public int levelOffset;
    public int score;
    public string levelName;
    public string colorName;

    [System.Serializable]
    class Score    //     -------- Data for Json       
    {
        public int score;
        public int levelOffset;
    }
    
    public void SaveData() //Transfering data into Json Format
    {
        Score data = new Score();
        data.score = score;
        data.levelOffset = levelOffset;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile" + levelOffset.ToString() +".json", json); //To use files   
    }
    public void LoadData() //Transfering data from Json Format
    {

        string path = Application.persistentDataPath + "/savefile" + levelOffset.ToString() + ".json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Score data = JsonUtility.FromJson<Score>(json);
            score = data.score;
            levelOffset = data.levelOffset;
        }
        else
        {
            score = 0;
        }
        
    }
  
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

}
