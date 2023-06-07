using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSet : MovingObject
{
    private void LateUpdate()
    {
        if(!GameManager.instance.gameOver)
        Move();
        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }  
}
