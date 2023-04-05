using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    public LogicScript logic;
    public PlayerScript player;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    public SpriteRenderer sprite;
    public float health = 10;
    public float iFrames = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        target = GameObject.Find("Player").transform;
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
            Destroy(gameObject);
        }
    }

    public void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
}
