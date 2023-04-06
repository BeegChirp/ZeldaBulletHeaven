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
    public bool alive = true;
    public SpriteRenderer sprite;
    Vector2 moveDirection = Vector2.zero;
    public bool immune = false;
    public int iFrames = 0;
    public Animator animator;

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
        if(health <= 0)
        {
            logic.gameOver();
            alive = false;
            rb.velocity = new Vector2(0,0);
        }

        if (Input.mousePosition.x <= Screen.width/2 && alive == true)
        {
            sprite.flipX = true;
        }
        else if (Input.mousePosition.x > Screen.width / 2 && alive == true)
        {
            sprite.flipX = false;
        }
    }
    private void FixedUpdate()
    {

        if (alive == true)
        {
            animator.SetFloat("SpeedX", moveDirection.x);
            animator.SetFloat("SpeedY", moveDirection.y);
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }

        if(iFrames > 0)
        {
            iFrames --;
        }
    }
}
