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
    public GameObject levelUpScreen;
    public LogicScript logic;
    public InputAction playerMovement;
    public LevelUpScript bigUps;
    public EnemySpawnScript spawner;
    public SpriteRenderer sprite;
    public AutoScript auto;
    public MenuScript menu;
    public Animator animator;
    public TextMeshProUGUI hpDisplay;
    public TextMeshProUGUI levelCounter;
    public int iFrames = 0;
    public int[] weapon = { 0 };
    public int[] acquiredStuff; //Type of weapon, item, or skill || Current level of each weapon, item, and skill that have been acquired in any given run.
    public int xpProgress = 0;
    public int currentLevel = 0;
    public float moveSpeed = 15;
    public float health = 10;
    public float maxHealth;
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
        Time.timeScale = 1f;
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
        if(Time.timeScale == 1)
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
        if (pickupRange > 10f)
        {
            pickupRange = 10f;
        }
        if (xpProgress >= 10)
        {
            xpOverflow = xpProgress - 10;
            currentLevel++;
            xpProgress = xpOverflow;
            levelCounter.text = "Level: " + (currentLevel+1).ToString();
            levelUpScreen.SetActive(true);
            bigUps.levelUp();
        }
        hpDisplay.text = "Health: " + health.ToString();
    }
    private void FixedUpdate()
    {
        if (health > 0)
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