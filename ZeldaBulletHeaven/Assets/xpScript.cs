using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpScript : MonoBehaviour
{
    public PlayerScript player;
    public Transform playerPos;
    public LogicScript logic;
    Vector2 playerXY;
    Vector2 xpXY;
    private bool pickedUp = false;
    float moveSpeed;
    private Vector3 direction;
    Vector2 moveDirection;
    public Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Play Boi").GetComponent<PlayerScript>();
        playerPos = GameObject.FindGameObjectWithTag("Play Boi").GetComponent<Transform>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        moveSpeed = (player.moveSpeed * -1.4f);
        direction = Vector3.zero;
    }
    void Update()
    {
        playerXY = new Vector2(playerPos.position.x, playerPos.position.y);
        xpXY = new Vector2(transform.position.x, transform.position.y);
        if (Vector2.Distance(playerXY, xpXY) <= player.pickupRange)
        {
            pickedUp = true;
            direction = (playerPos.position - transform.position).normalized;
        }
        if (pickedUp)
        {
            if(moveSpeed>0) direction = (playerPos.position - transform.position).normalized;
            moveDirection = direction;
        }
    }
    public void FixedUpdate()
    {
        if (pickedUp)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
            if (moveSpeed > 0)
            {
                moveSpeed += (moveSpeed * 0.022f);
            }
            moveSpeed += player.moveSpeed*0.06f;
        }
        //else transform.position = logic.zDepth(transform.position);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if(moveSpeed > 0)
            {
            player.xpProgress++;
            Destroy(gameObject);
            }
        }
    }
}

