using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Transform playerPos;
    public LogicScript logic;
    public AutoScript auto;
    public Rigidbody2D rb;
    public float aimAngle;
    [SerializeField] float bulletForce = 0.3f;
    public float lifespan = 25;
    private int hitCount = 0;
    private int maxHitCount = 3;
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Play Boi").GetComponent<Transform>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        auto = GameObject.FindGameObjectWithTag("Auto").GetComponent<AutoScript>();
        rb = GameObject.FindGameObjectWithTag("Arrow").GetComponent<Rigidbody2D>();
        //transform.rotation = logic.aim(transform.position);
        //aimAngle = logic.angle;
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }
    private void FixedUpdate()
    {
        if (lifespan <= 0 || hitCount >= maxHitCount)
        {
            Destroy(gameObject);
        }
        lifespan--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            hitCount++;
        }
    }
}
