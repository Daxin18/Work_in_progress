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
    public float movementSpeed = 2.0f;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        //animator = this.GetComponent<Animator>(); //for animations
        rigidBody = this.GetComponent<Rigidbody2D>(); //aka player body
        Physics.IgnoreLayerCollision(6, 7); //ignores collisions betweeen layer 6 (Player) and 7 (Finish)
    }
    
    void FixedUpdate()
    {
        rigidBody.rotation = 0f; //to make sure player character does not spin around
        rigidBody.velocity = direction * movementSpeed;

        //flipping from left to right, might change to also flip vertically
        if ((!facingRight && direction.x > 0f) || (facingRight && direction.x < 0f))
        {
            _Flip();
        }
        //setting variables to go between animation states
        if (direction != Vector2.zero)
        {
            //animator.SetBool("isWalking", true);
        }
        else
        {
            //animator.SetBool("isWalking", false);
        }
    }

    //called on move
    public void _Move(InputAction.CallbackContext context)
    {
        //animator.SetBool("isWalking", true);
        //Debug.Log(direction); //for testing purposes
        direction = context.action.ReadValue<Vector2>();
    }

    //flips player character horizontally
    private void _Flip()
    {
        facingRight = !facingRight;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }
}
