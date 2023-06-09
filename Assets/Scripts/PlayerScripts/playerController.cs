using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    public GameObject deadBody; //reference to a dead body for a multiplayer level

    private Vector2 direction = Vector2.zero;
    public float movementSpeed = 2.0f;
    private bool facingRight = true;
    public bool isMovementBlocked = false;

    private Vector2 startingPosition = new Vector2(-10, 0); //starting point of any level

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = startingPosition;
        animator = this.GetComponent<Animator>(); //for animations
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
        /*if (direction != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }*/
        if (direction == Vector2.zero)
        {
            //animator.SetBool("isWalking", false);
            animator.SetInteger("WalkingDirection", 0);
        }
    }

    //called on move
    public void _Move(InputAction.CallbackContext context)
    {
        //animator.SetBool("isWalking", true);
        //Debug.Log(direction); //for testing purposes
        if (!isMovementBlocked)
        {
            direction = context.action.ReadValue<Vector2>();
            animator.SetInteger("WalkingDirection", Math.Abs(direction.x) > Math.Abs(direction.y) ? 1 : direction.y > 0 ? 2 : 3);
        }
        /*        if (Math.Abs(direction.x) > Math.Abs(direction.y))
                {
                    animator.SetInteger("walikingVariante", 1);
                }
                else
                {
                    animator.SetInteger("walikingVariante", Math.Abs(direction.x) > Math.Abs(direction.y) ? 1 : direction.y > 0 ? 2 : 3);
                }*/

    }

    //flips player character horizontally
    private void _Flip()
    {
        facingRight = !facingRight;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }

    public void Die()
    {
        deadBody.transform.position = gameObject.transform.position; //teleport dead body to current position
        gameObject.transform.position = startingPosition; //reset player position
    }
}
