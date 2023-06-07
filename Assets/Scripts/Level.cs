using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static Level instance;
    public int levelOffset;
    public GameObject rightButton;
    public GameObject leftButton;

    public enum LevelType
    {
        EASY,
        MEDIUM,
        HARD
    };
    public LevelType levelType;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        
        
    }

    private void Start()
    {
        SwitchLevel();
    }

    public void PressRight()//Incrementing difficulty
    {

        levelOffset++;       
        SwitchLevel();
    }
    public void PressLeft()//Decrementing difficulty
    {
        levelOffset--;       
        SwitchLevel();
    }

    private void SwitchLevel()//Changing states of buttons
    {
        switch (levelOffset)
        {
            case 0:
                rightButton.SetActive(true);
                leftButton.SetActive(false);
                break;
            case 1:
                leftButton.SetActive(true);
                rightButton.SetActive(true);
                break;
            case 2:
                leftButton.SetActive(true);
                rightButton.SetActive(false);
                break;
        }
        levelType = (LevelType)levelOffset;
    }

    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

}
