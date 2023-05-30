using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    //private Animator animator;
    private Rigidbody2D rigidBody;

    private Vector2 direction = Vector2.zero;
    public float maxSpeed = 4.0f;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        //animator = this.GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        rigidBody.rotation = 0f;
        rigidBody.velocity = direction * maxSpeed;

        if ((!facingRight && direction.x > 0f) || (facingRight && direction.x < 0f))
        {
            _Flip();
        }
        if (direction != Vector2.zero)
        {
            //animator.SetBool("isWalking", true);
        }
        else
        {
            //animator.SetBool("isWalking", false);
        }
    }

    public void _Move(InputAction.CallbackContext context)
    {
        //animator.SetBool("isWalking", true);
        Debug.Log(direction);
        direction = context.action.ReadValue<Vector2>();
    }

    private void _Flip()
    {
        facingRight = !facingRight;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }
}
