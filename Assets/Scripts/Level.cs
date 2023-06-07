using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static Level instance;
    public int levelOffset;
    public enum LevelType
    {
        EASY,
        MEDIUM,
        HARD
    };
    public LevelType levelType;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        SetLevelType();
    }

    public void SetLevelType()
    {
        levelType = (LevelType)levelOffset;
    }
}
