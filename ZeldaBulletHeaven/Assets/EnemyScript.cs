using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    Vector2 moveDirection;
    Rigidbody2D rb;
    Transform target;
    public LogicScript logic;
    public PlayerScript player;
    public GameObject XP;
    public SpriteRenderer sprite;
    public float health = 1;
    public float damage = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Play Boi").GetComponent<PlayerScript>();
        target = GameObject.FindGameObjectWithTag("Play Boi").transform;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //XP = GameObject.FindGameObjectWithTag("XP");
    }

    // Update is called once per frame
    public void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }

        if (moveDirection.x > 0)
        {
            sprite.flipX = true;
        }
        else if (moveDirection.x < 0)
        {
            sprite.flipX = false;
        }

        if (health <= 0)
        {
            Instantiate(XP, transform.position, Quaternion.identity);
            Destroy(gameObject);
            logic.killCounter();
        }
    }

    public void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed * Time.fixedDeltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && player.iFrames <= 0)
        {
            logic.playerDamage(damage);
            player.iFrames = 10;
        }
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            health = logic.dealDamage(health, 0, new Vector3(transform.position.x + 0.4f, transform.position.y + 2.2f, -4));
        }
    }
}