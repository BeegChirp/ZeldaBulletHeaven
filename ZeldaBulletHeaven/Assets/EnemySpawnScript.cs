using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public LogicScript logic;
    public Transform playerPos;
    public GameObject darknut;
    public int spawnTimer = 50;
    public int spawnDirection;
    public Vector3 offScreenUp;
    public Vector3 offScreenDown;
    public Vector3 offScreenLeft;
    public Vector3 offScreenRight;
    void Update()
    {
        transform.position = logic.followPlayer(0);
        offScreenUp = new Vector3(playerPos.position.x + Random.Range(-120, 120), playerPos.position.y + 75, 0.7f);
        offScreenDown = new Vector3(playerPos.position.x + Random.Range(-120,120), playerPos.position.y - 75, 0.7f);
        offScreenLeft = new Vector3(playerPos.position.x - 120, playerPos.position.y + Random.Range(-75, 75), 0.7f);
        offScreenRight = new Vector3(playerPos.position.x + 120, playerPos.position.y + Random.Range(-75, 75), 0.7f);
        Debug.Log(offScreenUp + " " + offScreenDown + " " + offScreenLeft + " " + offScreenRight);
    }
    private void FixedUpdate()
    {

        spawnDirection = Random.Range(0, 4);
        if (spawnDirection == 0)
        {
            if (spawnTimer <= 0)
            {
                SpawnDarknut(offScreenUp);
                spawnTimer = 50;
            }
            else
            {
                spawnTimer--;
            }
        }
        else if (spawnDirection == 1)
        {
            if (spawnTimer <= 0)
            {
                SpawnDarknut(offScreenDown);
                spawnTimer = 50;
            }
            else
            {
                spawnTimer--;
            }
        }
        else if (spawnDirection == 2)
        {
            if (spawnTimer <= 0)
            {
                SpawnDarknut(offScreenLeft);
                spawnTimer = 50;
            }
            else
            {
                spawnTimer--;
            }
        }
        else
        {
            if (spawnTimer <= 0)
            {
                SpawnDarknut(offScreenRight);
                spawnTimer = 50;
            }
            else
            {
                spawnTimer--;
            }
        }
    }

    public void SpawnDarknut(Vector3 spawnPos)
    {
        Instantiate(darknut, spawnPos, Quaternion.identity);
    }
}