using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public Transform playerPos;
    public LogicScript logic;
    public float lifespan = 25;
    public AutoScript auto;
    public float aimAngle;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Play Boi").GetComponent<Transform>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        auto = GameObject.FindGameObjectWithTag("Auto").GetComponent<AutoScript>();
        transform.position = new Vector3(auto.weaponOrigin.x + playerPos.position.x, auto.weaponOrigin.y + playerPos.position.y, -1);
        transform.rotation = logic.aim(transform.position);
        aimAngle = logic.angle;
    }

    private void Update()
    {
        //Debug.Log(aimAngle);
        transform.position = new Vector3(auto.weaponOrigin.x + playerPos.position.x, auto.weaponOrigin.y + playerPos.position.y, -1);
        /*Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.position, logic.attackRange, aimAngle, logic.enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            logic.dealDamage();
        }*/

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(lifespan <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifespan--;
        }
    }

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, logic.attackRange);
    }*/

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            logic.dealDamage();
        }
    }
}
