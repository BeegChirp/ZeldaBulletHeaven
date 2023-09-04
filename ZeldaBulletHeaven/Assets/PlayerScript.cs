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
    public LevelUpScript lvlUp;
    public EnemySpawnScript spawner;
    public SpriteRenderer sprite;
    public AutoScript auto;
    public MenuScript menu;
    public Animator animator;
    public TextMeshProUGUI hpDisplay, levelCounter;
    public int iFrames = 0;
    public string[] skillNames;
    public int[,] weaponInventory, itemInventory;
    public int[] skills;
    public float health, maxHealth, attack, attackMult, moveSpeed, moveSpeedMult, criticalChance, criticalDamageMult, haste, pickupRange, luck;
    public int xpProgress, currentLevel;
    private int xpOverflow;
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
        criticalChance = 10;
        criticalDamageMult = 1.5f;
        haste = 1;
        pickupRange = 3f;
        luck = 0;
        Time.timeScale = 1f;
    }
    private void Start()
    {
        weaponInventory = new int[6, 2] //weaponID, currentWeaponLevel
        {
            {0, 0}, {-1, -1}, {-1, -1}, {-1, -1 }, {-1, -1 }, {-1, -1 } //player starts with character unique weapon
        };
        itemInventory = new int[6, 2] //itemID, currentItemLevel
        {
            {-1, -1}, {-1, -1}, {-1, -1}, {-1, -1 }, {-1, -1 }, {-1, -1 }
        };
        skills = new int[3] { 0, 0, 0 };
        skillNames = new string[1] { //3
            "Extra Ammo"/*, "Heart Container", "Shield Parry"*/
        };
        currentLevel = 0;
        xpProgress = 0;
        xpOverflow = 0;
    }
    void Update()
    {
        moveDirection = playerMovement.ReadValue<Vector2>();
        if (health <= 0) //if player dies
        {
            logic.GameOver(); //gameover
            rb.velocity = new Vector2(0, 0); //stop moving
        }
        if (Time.timeScale == 1)
        {
            if (Input.mousePosition.x <= Screen.width / 2)
            {
                sprite.flipX = true; //turn the player sprite around if looking left
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
            levelCounter.text = "Level: " + (currentLevel + 1).ToString();
            levelUpScreen.SetActive(true);
            lvlUp.LevelUp();
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