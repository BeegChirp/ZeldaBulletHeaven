using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScript : MonoBehaviour
{
    public Transform playerPos;
    public PlayerScript player;
    public LogicScript logic;
    public ArrowScript arrowScript;
    public float swordHaste = 100;
    public float swordCooldown = 100;
    public GameObject attack;
    public float bowHaste = 100;
    public float bowCooldown;
    public GameObject bowProjectile;
    //public float xVar, yVar;
    //public Vector3 weaponOrigin;
    //public float offsetScale = 10;

    // Start is called before the first frame update
    void Update()
    {
        /*Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x);
        Vector2 runRise = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        xVar = runRise.x * offsetScale;
        yVar = runRise.y * offsetScale;*/
        transform.position = logic.followPlayer(-1);
        transform.rotation = logic.aim(transform.position);
        if(swordHaste <= 3)
        {
            swordHaste = 3;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (swordCooldown <= 0 && player.health > 0)
        {
            Instantiate(attack, transform.position, logic.aim(playerPos.position));
            swordCooldown = swordHaste;
        }
        else
        {
            swordCooldown--;
        }
        bowAttack();
    }
    void bowAttack()
    {
        if (bowCooldown <= 0 && player.health > 0)
        {
            Instantiate(bowProjectile, transform.position, logic.aim(playerPos.position));
            bowCooldown = bowHaste;
        }
        else
        {
            bowCooldown--;
        }
    }
}
