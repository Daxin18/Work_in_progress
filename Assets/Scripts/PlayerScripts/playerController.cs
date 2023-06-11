using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    public GameObject deadBody; //reference to a dead body for a multiplayer level

    private Vector2 direction = Vector2.zero;
    public float movementSpeed = 2.0f;
    private bool facingRight = true;

    public bool isMovementBlocked = false;
    public bool invertMovement = false;

    private Vector2 startingPosition = new Vector2(-10, 0); //starting point of any level

    public bool spawnInTheMiddle = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = startingPosition;
        if (spawnInTheMiddle)
        {
            gameObject.transform.position = Vector2.zero;
        }
        animator = this.GetComponent<Animator>(); //for animations
        rigidBody = this.GetComponent<Rigidbody2D>(); //aka player body
        Physics.IgnoreLayerCollision(6, 7); //ignores collisions betweeen layer 6 (Player) and 7 (Finish)
    }

    void FixedUpdate()
    {
        //rigidBody.rotation = 0f; //to make sure player character does not spin around
        rigidBody.velocity = direction * movementSpeed;

        if(invertMovement)
        {
            /*float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Pobierz aktualn� rotacj� postaci
            Quaternion rotation = transform.rotation;

            // Konwertuj rotacj� na k�t w stopniach
            float angle = rotation.eulerAngles.z;

            // Oblicz nowy kierunek poruszania si� postaci na podstawie k�ta
            Vector2 movementDirection = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            // Oblicz wektor pr�dko�ci na podstawie wej�cia u�ytkownika
            Vector3 velocity = new Vector3(movementDirection.x, movementDirection.y, 0f) * movementSpeed;
            velocity += new Vector3(horizontalInput, verticalInput, 0f) * movementSpeed;

            // Dodaj si�� do ruchu postaci
            transform.position += velocity * Time.deltaTime;*/
            /*Quaternion rotation = transform.rotation;
            float angle = rotation.eulerAngles.z;
            Vector2 movementDirection = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movementDirection.x, movementDirection.y, 0f) * horizontalInput * movementSpeed * Time.deltaTime;*/
            //rigidBody.velocity *= -new Vector3(movementDirection.x, 0f, movementDirection.y);
            rigidBody.velocity *= -1;
        }
        //else rigidBody.velocity = direction * movementSpeed;

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
