using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public LogicScript logic;
    public InputAction playerMovement;
    public EnemySpawnScript spawner;
    public SpriteRenderer sprite;
    public AutoScript auto;
    public MenuScript menu;
    public Animator animator;
    public TextMeshProUGUI hpDisplay;
    public TextMeshProUGUI levelCounter;
    public int iFrames = 0;
    public int[] weapon = { 0 };
    public int[] itemLevels;
    public int xpProgress = 0;
    public int currentLevel = 0;
    public float moveSpeed = 100;
    public float health = 10;
    public float pickupRange = .2f;
    int xpOverflow;
    Vector2 moveDirection = Vector2.zero;
    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }

    private void Start()
    {
        pickupRange = 3f;
        //levelCounter.text = "Level: " + currentLevel.ToString();
    }

    void Update()
    {
        moveDirection = playerMovement.ReadValue<Vector2>();
        if (health <= 0)
        {
            logic.gameOver();
            rb.velocity = new Vector2(0, 0);
        }
        else if(menu.pauseBool == false)
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
        if (pickupRange >= 10f)
        {
            pickupRange = 10f;
        }
        if (xpProgress >= 10)
        {
            xpOverflow = xpProgress - 10;
            currentLevel++;
            auto.haste = auto.haste - currentLevel;
            pickupRange = pickupRange + 1;
            spawner.scaledTimer = spawner.scaledTimer - currentLevel;
            xpProgress = xpOverflow;
            levelCounter.text = "Level: " + currentLevel.ToString();
        }
        hpDisplay.text = "Health: " + health.ToString();

        //xpDisplay.text = "XP: " + xpProgress.ToString();
    }

    private void FixedUpdate()
    {

        if (health >= 0)
        {
            animator.SetFloat("SpeedX", moveDirection.x);
            animator.SetFloat("SpeedY", moveDirection.y);
            rb.velocity = new Vector2(moveDirection.x * moveSpeed * Time.fixedDeltaTime, moveDirection.y * moveSpeed * Time.fixedDeltaTime);
        }

        if (iFrames > 0)
        {
            iFrames--;
        }
    }
}
