using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed;
    Vector2 moveDirection;
    Rigidbody2D rb;
    Transform target;
    public LogicScript logic;
    public PlayerScript player;
    public GameObject XP;
    public DataBase data;
    public SpriteRenderer sprite;
    public int iframes;
    public float health = 1;
    public float damage = 1;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Play Boi").GetComponent<PlayerScript>();
        target = GameObject.FindGameObjectWithTag("Play Boi").transform;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataBase>();
        moveSpeed = 2;
    }

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
            Instantiate(XP, new Vector3(transform.position.x, transform.position.y, 2), Quaternion.identity);
            Destroy(gameObject);
            logic.KillCounter();
        }
        if (player.hellMode)
        {
            moveSpeed = 20;
        }
        else
        {
            moveSpeed = 2;
        }
    }
    public void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
        transform.position = logic.ZDepth(transform.position);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && player.iFrames <= 0)
        {
            logic.PlayerDamage(damage);
            player.iFrames = 10;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int weaponSlot = -1;
        if (collision.gameObject.layer == 7)
        {
            int weapon = logic.GetCollisionID(collision.gameObject.tag);
            int damage;
            if (weapon < data.weaponNames.Length + data.itemNames.Length + data.statUpNames.Length + 3)
            {
                for (int a = 0; a < (player.weaponInventory.Length / 2); a++) //look through weapon inventory
                {
                    if (weapon == player.weaponInventory[a, 0]) weaponSlot = a;
                }
                damage = (int)data.WeaponStats[weapon, 0, player.weaponInventory[weaponSlot, 1]];
                damage = (int)Mathf.Round(damage + Random.Range(data.WeaponStats[weapon, 0, player.weaponInventory[weaponSlot, 1]] * 0.1f, data.WeaponStats[weapon, 0, player.weaponInventory[weaponSlot, 1]] * -0.1f));
            }
            else
            {
                Debug.Log(weapon);
                weapon = weapon - data.names.Length;
                Debug.Log(weapon);
                damage = (int)data.miscDamageTypes[weapon];
                damage = (int)Mathf.Round(damage + Random.Range(data.miscDamageTypes[weapon] * 0.1f, data.miscDamageTypes[weapon] * -0.1f));
            }
            health = logic.DealDamage(health, damage, new Vector3(transform.position.x + 0.4f, transform.position.y + 2.2f, -4));
        }
    }
}