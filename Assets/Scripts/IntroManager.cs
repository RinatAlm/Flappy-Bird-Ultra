using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    private Level level;
    public GameObject rightButton;
    public GameObject leftButton;
    public GameObject settingsPanel;
    private void Start()
    {
        level = Level.instance;
        SwitchLevel();
    }

    public void ClickRight()//Incrementing difficulty
    {

        level.levelOffset++;
        SwitchLevel();
    }
    public void ClickLeft()//Decrementing difficulty
    {
        level.levelOffset--;
        SwitchLevel();
    }

    private void SwitchLevel()//Changing states of buttons
    {
        switch (level.levelOffset)
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
        level.SetLevelType();

    }

    public void GameStart()
    {
        
        SceneManager.LoadScene("GameScene");
    }

    public void SettingsClick()
    {
        if(!settingsPanel.activeSelf)
        {    
            
            settingsPanel.SetActive(true);
        }
        else
        {
            settingsPanel.SetActive(false);
        }
    }

    //private IEnumerator SettingsCoroutine()
    //{
    //    Animator animator = GetComponent<Animator>();

    //    if (animator)
    //    {
    //       // animator.Play(clearAnimation.name);
    //    }
    //    yield return new WaitForSeconds(clearAnimation.length);
    //    Destroy(gameObject);
    //}

    
}
