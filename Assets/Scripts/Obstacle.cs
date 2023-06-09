using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!GameManager.instance.gameOver)
            {
                GameManager.instance.GameOver();
                AudioManager.instance.Stop("MainMusic");
                AudioManager.instance.Play("GameOver");
            }
           
        }

    }

}
