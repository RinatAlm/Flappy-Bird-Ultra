using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.score++;
            GameManager.instance.scoreText.text = GameManager.instance.score.ToString();
            AudioManager.instance.Play("Confirm");
        }
    }
       
}
