using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using AppsFlyerSDK;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public static IntroManager instance;
    private Level level;   
    public GameObject rightButton;
    public GameObject leftButton;
    public GameObject settingsPanel;
    public Text levelText;   
    public GameObject bg;
    public GameObject slider;
    public AppsFlyerObjectScript objectScript;
    private void Awake()
    {
        instance = this;
        level = Level.instance;    
    }
    private void Start()
    {
        Debug.Log(AudioManager.instance.name);
        AudioManager.instance.LoadVolume();
        slider.GetComponent<Slider>().value = AudioManager.instance.volume;
        ChangeVolume();
        if(AudioManager.instance.isMainMusicRunning == false)
        AudioManager.instance.Play("MainMusic");     
        SwitchLevel();
        bg.GetComponent<MovingObject>().moveSpeed = 0.5f;
    }

    public void ClickRight()//Incrementing difficulty
    {
        level.levelOffset++;
        SwitchLevel();
        AudioManager.instance.Play("Button");
    }
    public void ClickLeft()//Decrementing difficulty
    {
        level.levelOffset--;
        SwitchLevel();
        AudioManager.instance.Play("Button");
    }

    private void SwitchLevel()//Changing states of buttons
    {
        
        switch (level.levelOffset)
        {
            case 0:
                rightButton.SetActive(true);
                leftButton.SetActive(false);
                level.levelName = "EASY";
                level.colorName = "green";
                break;
            case 1:
                leftButton.SetActive(true);
                rightButton.SetActive(true);
                level.levelName = "MEDIUM";
                level.colorName = "yellow";
                break;
            case 2:
                leftButton.SetActive(true);
                rightButton.SetActive(false);
                level.levelName = "HARD";
                level.colorName = "red";
                break;
        }       
        level.LoadData();
        levelText.text = " Level : " +"<color=" + level.colorName + ">" + level.levelName + "</color>" + "\n Max Score : " + level.score.ToString();
    }

    public void GameStart()
    {
        AudioManager.instance.SaveVolume();
        SceneManager.LoadScene("GameScene");
        AudioManager.instance.Play("Button");
    }

    public void SettingsClick()
    {
        if(!settingsPanel.activeSelf)
        {    
            
            settingsPanel.SetActive(true);
        }
        else
        {
            AudioManager.instance.SaveVolume();
            settingsPanel.SetActive(false);
        }
        AudioManager.instance.LoadVolume();
    }

   
    public void ChangeVolume()
    {
        AudioManager.instance.volume = slider.GetComponent<Slider>().value;
        AudioManager.instance.SetAudio();
        //AudioManager.instance.SaveVolume();
    }
}
