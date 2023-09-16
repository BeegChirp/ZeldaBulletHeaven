using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public Transform playerPos;
    public PlayerScript player;
    public DataBase data;
    public AutoScript auto;
    public GameObject beam;
    public LogicScript logic;
    public float lifespan = 25;
    public float aimAngle;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Play Boi").GetComponent<PlayerScript>();
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataBase>();
        /*beam = GameObject.FindGameObjectWithTag("Beam");*/
        Vector3 swordSize = transform.localScale;
        swordSize = swordSize * data.WeaponStats[0, 2, player.weaponInventory[0,1]] * player.size;
        transform.localScale = swordSize;
        playerPos = GameObject.FindGameObjectWithTag("Play Boi").GetComponent<Transform>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        auto = GameObject.FindGameObjectWithTag("Auto").GetComponent<AutoScript>();
        transform.rotation = logic.Aim(transform.position);
        if(player.weaponInventory[0,1] >= 6)
        {
            //instantiate a beam attack
            Instantiate(beam, auto.transform.position, logic.Aim(playerPos.position));
        }
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