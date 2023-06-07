using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float force = 100f;
    private Rigidbody2D rigidbody2d;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fly();
        }
    }

    private void Fly()
    {
        rigidbody2d.AddForce(Vector2.up * force,ForceMode2D.Impulse);
    }
}
