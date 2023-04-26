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
    public string[] skillNames;
    public int[,] weaponInventory;
    public int[,] itemInventory;
    public int xpProgress = 0;
    public int currentLevel = 0;
    public float health, maxHealth, attack, attackMult, moveSpeed, moveSpeedMult, criticalChance, criticalDamageMult, haste, pickupRange, luck;
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
    private void Awake()
    {
        maxHealth = 100;
        health = maxHealth;
        attackMult = 1;
        attack = 1;
        moveSpeed = 8.75f;
        moveSpeedMult = 1;
        pickupRange = 3f;

        Time.timeScale = 1f;
    }
    private void Start()
    {
        weaponInventory = new int[6, 2]
        {
            {0, 0}, {-1, -1}, {-1, -1}, {-1, -1 }, {-1, -1 }, {-1, -1 }
        };
        itemInventory = new int[6, 2]
        {
            {-1, -1}, {-1, -1}, {-1, -1}, {-1, -1 }, {-1, -1 }, {-1, -1 }
        };
        skillNames = new string[3] {
            "Link Skill 1", "Link Skill 2", "Link Skill 3"
        };   
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