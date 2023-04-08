using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public LogicScript logic;
    public Transform playerPos;
    public GameObject darknut;
    public int spawnTimer = 50;
    public float offScreenX = 120;
    public float offScreenY = 75;
    public int spawnDirection;
    private Vector3[] offScreen = new Vector3[4];
    /*offScreen[0] = new Vector3(0,0,0);
    offScreen[1] = new Vector3(0,0,0);
    offScreen[2] = new Vector3(0,0,0);
    offScreen[3] = new Vector3(0,0,0);*/

    private void Update()
    {
        transform.position = logic.followPlayer(0);
        offScreen[0] = new Vector3(playerPos.position.x + Random.Range(-offScreenX, offScreenX), playerPos.position.y + offScreenY, 0.7f);
        offScreen[1] = new Vector3(playerPos.position.x + Random.Range(-offScreenX, offScreenX), playerPos.position.y - offScreenY, 0.7f);
        offScreen[2] = new Vector3(playerPos.position.x - offScreenX, playerPos.position.y + Random.Range(-offScreenY, offScreenY), 0.7f);
        offScreen[3] = new Vector3(playerPos.position.x + offScreenX, playerPos.position.y + Random.Range(-offScreenY, offScreenY), 0.7f);
        //Debug.Log(offScreen[0] + " " + offScreen[1] + " " + offScreen[2] + " " + offScreen[3]);
    }
    private void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            spawnDirection = Random.Range(0, 4);
            SpawnDarknut(offScreen[spawnDirection]);
            spawnTimer = 50;
        }
        else
        {
            spawnTimer--;
        }
    }

    public void SpawnDarknut(Vector3 spawnPos)
    {
        Instantiate(darknut, spawnPos, Quaternion.identity);
    }
}