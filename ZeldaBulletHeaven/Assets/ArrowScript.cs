using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Transform playerPos;
    public LogicScript logic;
    public AutoScript auto;
    public Rigidbody2D rb;
    public Vector2 direction;
    public float aimAngle;
    [SerializeField] float bulletForce = 0.15f;
    public float lifespan;
    public int startup;
    private int hitCount = 0;
    private int maxHitCount = 3;
    public int ID;
    void Start()
    {
        lifespan = 200;
        startup = 25;
        ID = 1;
        playerPos = GameObject.FindGameObjectWithTag("Play Boi").GetComponent<Transform>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        auto = GameObject.FindGameObjectWithTag("Auto").GetComponent<AutoScript>();
        //rb = GameObject.FindGameObjectWithTag("Arrow").GetComponent<Rigidbody2D>();
        //transform.rotation = logic.aim(transform.position);
        //aimAngle = logic.angle;
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //find where the mouse is compared to the center of the screen
        direction.Normalize();
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse); //send arrow in the direction of the mouse
    }
    private void FixedUpdate()
    {
        /*startup--;
        if(startup <= 0)
        {
            rb.AddForce(direction * bulletForce, ForceMode2D.Impulse); //send arrow in the direction of the mouse
        }*/
        if (lifespan <= 0 || hitCount >= maxHitCount) //destroy arrow after it's hit max # of enemies or when its lifespan reaches 0
        {
            Destroy(gameObject);
        }
        lifespan--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //count the # of times arrow hits an enemy
        {
            hitCount++;
        }
    }
}
