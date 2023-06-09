using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float force = 100f;
    [SerializeField]
    private AnimationClip animationClip;
    private Rigidbody2D rigidbody2d;
    Animator animator;

   

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!GameManager.instance.gameOver)
        {

            if (Input.touchCount > 0)
            {
                Touch theTouch = Input.GetTouch(0);
                if (theTouch.phase == TouchPhase.Began)
                {
                    Fly();
                }
            }
        }
        
    }

    private void Fly()
    {
        animator.Play(animationClip.name);        
        rigidbody2d.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        AudioManager.instance.Play("Jump");
    }
}
