using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1;
    [SerializeField]
    private Vector3 bgReversePos;
    public Vector3 positionChange = Vector3.left;

    private void LateUpdate()
    {
        if(transform.position.x <= bgReversePos.x)
        {
            transform.position = Vector3.zero;
        }
        Move();
    }
    public virtual void Move()
    {
        transform.position += (positionChange * moveSpeed * Time.deltaTime);
    }
}
