using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpScript : MonoBehaviour
{
    public PlayerScript player;
    public Transform playerPos;
    Vector2 playerXY;
    Vector2 xpXY;
    public bool pickedUp = false;
    float moveSpeed = -450f;
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
    }
    void Update()
    {
        playerXY = new Vector2(playerPos.position.x, playerPos.position.y);
        xpXY = new Vector2(transform.position.x, transform.position.y);
        if (Vector2.Distance(playerXY, xpXY) <= player.pickupRange)
        {
            pickedUp = true;
        }
        if (pickedUp == true)
        {
            Vector3 direction = (playerPos.position - transform.position).normalized;
            moveDirection = direction;
        }
    }
    public void FixedUpdate()
    {
        if (pickedUp == true)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed * Time.fixedDeltaTime;
            if (moveSpeed > 0)
            {
                moveSpeed = moveSpeed + (moveSpeed * 0.022f);
            }
            moveSpeed = moveSpeed + 20f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
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

