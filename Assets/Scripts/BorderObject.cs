using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)//End of the game if pass through border
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
}
