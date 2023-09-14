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
    public bool hellMode = false;
    public GameObject XP;
    public MenuScript menu;
    public Animator animator;
    public TextMeshProUGUI hpDisplay, levelCounter;
    public PlayerControls playerControls;
    public int iFrames = 0;
    public string[] skillNames;
    public int[,] weaponInventory, itemInventory;
    public int[] skills;
    public float health, maxHealth, attack, moveSpeed, moveSpeedMult, criticalChance, criticalDamageMult, haste, pickupRange, luck, size;
    public int xpProgress, currentLevel;
    public int xpOverflow;
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
        //moveDirection = playerMovement.ReadValue<Vector2>();
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
        if (xpProgress >= 10 && health > 0)
        {
            currentLevel++;
            xpProgress = 0;
            levelCounter.text = "Level: " + (currentLevel + 1).ToString();
            levelUpScreen.SetActive(true);
            lvlUp.LevelUp();
        }
        hpDisplay.text = "Health: " + health.ToString();
        if (hellMode)
        {
            spawner.scaledTimer = 5;
        }
        else
        {
            spawner.scaledTimer = 50;
        }
    }
    private void FixedUpdate()
    {
        if (health > 0)
        {
            animator.SetFloat("SpeedX", moveDirection.x);
            animator.SetFloat("SpeedY", moveDirection.y);
        }

        if (iFrames > 0)
        {
            iFrames--;
        }

        if (xpOverflow > 0)
        {
            xpOverflow--;
            xpProgress++;
        }
    }

    private void OnMove(InputValue inputValue)
    {
        rb.velocity = inputValue.Get<Vector2>() * moveSpeed;
    }

    private void OnSpawnXP()
    {
        for (int xp = 0; xp < 100; xp++)
        {
            Instantiate(XP, transform);
        }
    }
    private void OnHellMode()
    {
        hellMode =! hellMode;
    }
}