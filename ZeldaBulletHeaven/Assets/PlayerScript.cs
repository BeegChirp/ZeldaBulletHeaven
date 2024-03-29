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
    /*public InputAction playerMovement;*/
    public LevelUpScript lvlUp;
    public EnemySpawnScript spawner;
    public SpriteRenderer sprite;
    public AutoScript auto;
    public GameObject XP;
    public MenuScript menu;
    public Animator animator;
    public TextMeshProUGUI hpDisplay;
    public PlayerControls playerControls;
    public int iFrames = 0;
    public string[] skillNames;
    public int[,] weaponInventory, itemInventory;
    public int[] skills;
    public float health, maxHealth, attack, moveSpeed, moveSpeedMult, criticalChance, criticalDamageMult, haste, pickupRange, luck, size;
    public int xpProgress, xpOverflow, currentLevel;
    Vector2 moveDirection = Vector2.zero;
    /*private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }*/
    private void Awake()
    {
        maxHealth = 100;
        health = maxHealth;
        attack = 1;
        moveSpeed = 8.75f;
        moveSpeedMult = 1;
        criticalChance = 10;
        criticalDamageMult = 1.5f;
        haste = 1;
        size = 1;
        pickupRange = 3f;
        luck = 0;
        Time.timeScale = 1f;
    }
    private void Start()
    {
        playerControls = new PlayerControls();
        weaponInventory = new int[6, 2] //weaponID, currentWeaponLevel
        {
            {0, 0}, {-1, -1}, {-1, -1}, {-1, -1 }, {-1, -1 }, {-1, -1 } //player starts with character unique weapon
        };
        itemInventory = new int[6, 2] //itemID, currentItemLevel
        {
            {-1, -1}, {-1, -1}, {-1, -1}, {-1, -1 }, {-1, -1 }, {-1, -1 }
        };
        skills = new int[3] { -1, -1, -1 };
        skillNames = new string[1] { //3
            "Extra Ammo"/*, "Heart Container", "Shield Parry"*/
        };
        currentLevel = 0;
        xpProgress = 0;
        xpOverflow = 0;
    }
    void Update()
    {
        if (health <= 0) //if player dies
        {
            health = 0; //no negative health
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
        hpDisplay.text = "Health: " + health.ToString();
    }
    private void FixedUpdate()
    {
        if (health > 0)
        {
            animator.SetFloat("SpeedX", moveDirection.x);
            animator.SetFloat("SpeedY", moveDirection.y);
        }
        if (xpOverflow > 0 && health > 0)
        {
            for (int i = 5; i >= 1; i--)
            {

                if (xpOverflow % i == 0)
                {
                    xpOverflow -= i;
                    xpProgress += i;
                }
            }
        }
        if (xpProgress >= 10)
        {
            lvlUp.LevelUp();
        }
        if (iFrames > 0)
        {
            iFrames--;
        }
    }
    private void OnMove(InputValue inputValue)
    {
        rb.velocity = inputValue.Get<Vector2>() * moveSpeed;
    }
}