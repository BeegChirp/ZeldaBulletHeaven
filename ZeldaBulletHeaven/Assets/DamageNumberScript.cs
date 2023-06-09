using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumberScript : MonoBehaviour
{
    public Rigidbody2D rb;
    int lifespan = 37;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
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
}
