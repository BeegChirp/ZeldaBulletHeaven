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
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Play Boi").GetComponent<Transform>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        auto = GameObject.FindGameObjectWithTag("Auto").GetComponent<AutoScript>();
        transform.rotation = logic.aim(transform.position);
        //aimAngle = logic.angle;
    }

    private void Update()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, -1);
    }
    private void FixedUpdate()
    {
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
        lifespan--;
    }
}
