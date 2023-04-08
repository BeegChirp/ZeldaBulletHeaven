using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScript : MonoBehaviour
{
    public Transform playerPos;
    public PlayerScript player;
    public LogicScript logic;
    public float haste = 100;
    public float cooldown = 100;
    public GameObject attack;
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

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cooldown <= 0 && player.health > 0)
        {
            //weaponOrigin = new Vector3(xVar, yVar, -1);
            Instantiate(attack, transform.position, logic.aim(playerPos.position));
            cooldown = haste;
        }
        else
        {
            cooldown--;
        }
    }
}
