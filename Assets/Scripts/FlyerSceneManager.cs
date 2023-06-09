using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using AppsFlyerSDK;

public class FlyerSceneManager : MonoBehaviour
{
    
    private void Start()
    {     
        
        
    }
    public void LoadMainGame()
    {
      
        SceneManager.LoadScene("IntroScene");
    }

}
