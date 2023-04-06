using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5;
    public LogicScript logic;
    public InputAction playerMovement;
    public float health = 10;
    public SpriteRenderer sprite;
    Vector2 moveDirection = Vector2.zero;
    public int iFrames = 0;
    public Animator animator;
    public int[] weapon = { 0 };
    public int[] itemLevels;
    public int level = 0;

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerMovement.ReadValue<Vector2>();
        if (health <= 0)
        {
            logic.gameOver();
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            if (Input.mousePosition.x <= Screen.width / 2)
            {
                sprite.flipX = true;
            }
            else if (Input.mousePosition.x > Screen.width / 2)
            {
                sprite.flipX = false;
            }
        }

    }

    private void FixedUpdate()
    {

        if (health >= 0)
        {
            animator.SetFloat("SpeedX", moveDirection.x);
            animator.SetFloat("SpeedY", moveDirection.y);
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }

        if (iFrames > 0)
        {
            iFrames--;
        }
    }
}
