using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float moveSpeed = 1;
    [SerializeField]
    private Vector3 bgReversePos = new Vector3(-50,0,0);
    public Vector3 positionChange = Vector3.left;
    

    private void LateUpdate()
    {


        if (transform.position.x <= bgReversePos.x)
        {
            transform.position = Vector3.zero;
        }
        Move();

    }
    public void Move()
    {
        transform.position += (positionChange * moveSpeed * Time.deltaTime);
    }
}
