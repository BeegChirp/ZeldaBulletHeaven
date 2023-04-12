using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumberScript : MonoBehaviour
{
    int lifespan = 25;
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
