using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpScript : MonoBehaviour
{
    public PlayerScript player;
    public Transform playerPos;
    public LogicScript logic;
    public Rigidbody2D rb;
    public DataBase data;
    public SpriteRenderer sprite;
    public Sprite sprite0, sprite10, sprite50, sprite200;
    private Sprite[] Sprites;
    public GameObject[] spawnedXP;
    private List<GameObject> nearbyXP = new List<GameObject>();
    private bool pickedUp = false;
    public int level;
    float moveSpeed;
    Vector3 direction;
    Vector2 playerXY;
    Vector2 xpXY;
    Vector2 moveDirection;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Play Boi").GetComponent<PlayerScript>();
        playerPos = GameObject.FindGameObjectWithTag("Play Boi").GetComponent<Transform>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataBase>();
        level = 0;
        Sprites = new Sprite[4] { sprite0, sprite10, sprite50, sprite200 };
        moveSpeed = (player.moveSpeed * -1.4f); //start with negative speed to move away from the player before being picked up
        direction = Vector3.zero;
    }
    void Update()
    {
        playerXY = new Vector2(playerPos.position.x, playerPos.position.y);
        xpXY = new Vector2(transform.position.x, transform.position.y);
        spawnedXP = GameObject.FindGameObjectsWithTag(gameObject.tag);
        if (Vector2.Distance(playerXY, xpXY) <= player.pickupRange)
        {
            pickedUp = true;
            direction = (playerPos.position - transform.position).normalized; //set direction toward the player from xp's location. xp will be moving away to start
        }
        if (pickedUp)
        {
            if (moveSpeed > 0) direction = (playerPos.position - transform.position).normalized; //adjust direction toward the player when speed is positive to collide with player
            moveDirection = direction;
        }
        else if (data.xpArray[level, 1] != -1)
        {
            for (int a = 0; a < spawnedXP.Length; a++)//make a list of nearby xp of the same level as the current xp
            {
                if (gameObject != spawnedXP[a] && Vector3.Distance(transform.position, spawnedXP[a].transform.position) <= 5 && gameObject.tag == spawnedXP[a].tag)
                {
                    nearbyXP.Add(spawnedXP[a]);
                    //spawnedXP[a].tag = "XP";
                }
            }
            if (nearbyXP.Count >= data.xpArray[level, 1])
            {
                //delete the old small xp's
                for (int b = data.xpArray[level, 1] - 1; b >= 0; b--)
                {
                    Destroy(nearbyXP[b]);
                }
                //update the level & tag of current xp
                level++;
                gameObject.tag = data.xpLevels[level];
            }
            nearbyXP.Clear();
        }
        sprite.sprite = Sprites[level];
    }
    public void FixedUpdate()
    {
        if (pickedUp)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed; //move
            if (moveSpeed > 0)
            {
                moveSpeed += (moveSpeed * 0.022f); //increase speed faster until speed is positive
            }
            moveSpeed += player.moveSpeed * 0.06f; //increase speed based on player's speed
            if (moveSpeed > 100)
            {
                moveSpeed = 100;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) //destroy xp once it collides with the player
        {
            if (moveSpeed > 0)
            {
                player.xpProgress += data.xpArray[level, 0]; //give xp
                Destroy(gameObject);
            }
        }
    }
}


