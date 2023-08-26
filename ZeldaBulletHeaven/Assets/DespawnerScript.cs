using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnerScript : MonoBehaviour
{
    public LogicScript logic;

    // Update is called once per frame
    void Update()
    {
        logic.FollowPlayer(-5);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
    }
}
