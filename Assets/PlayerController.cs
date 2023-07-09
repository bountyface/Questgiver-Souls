using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    // public SwordAttack swordAttack;

    Vector2 movementInput;
    Rigidbody2D rb;

    SpriteRenderer spriteRenderer;

    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            // basic movement
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);
                if (!success && movementInput.x > 0)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }
                if (!success && movementInput.y > 0)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
                // animator.SetBool("isMoving", success);
            }
            else
            {
                // animator.SetBool("isMoving", false);

            }

            // set direction of sprite to movement direction
            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;

            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }

        }
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = rb.Cast(
                   direction,
                   movementFilter,
                   castCollisions,
                   moveSpeed * Time.fixedDeltaTime + collisionOffset
                   );
            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        // print("Fire pressed!");
        // animator.SetTrigger("swordAttack");
    }


    // public void SwordAttack()
    // {
    //     LockMovement();
    //     if (spriteRenderer.flipX == true)
    //     {
    //         swordAttack.AttackLeft();
    //     }
    //     else
    //     {
    //         swordAttack.AttackRight();
    //     }
    // }

    // public void EndSwordAttack()
    // {
    //     UnlockMovement();
    //     swordAttack.StopAttack();
    // }

    public void LockMovement()
    {
        canMove = false;
    }
    public void UnlockMovement()
    {
        canMove = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        // print("Trigger Exit");
        if (collision.gameObject.CompareTag("Boundary"))
        {
            print("Boundary");
            transform.localPosition = new Vector3(0, 0, 0);
            // Handle collision with the boundary here
            // For example, you can reset the player's position or apply some other behavior
        }
    }
}
