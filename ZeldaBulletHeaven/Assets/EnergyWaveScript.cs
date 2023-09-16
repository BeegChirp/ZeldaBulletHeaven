using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWaveScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 direction;
    public int lifespan;
    public float bulletForce;

    private void Start()
    {
        bulletForce = 30;
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //find where the mouse is compared to the center of the screen
        direction.Normalize();
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse); //send arrow in the direction of the mouse
        lifespan = 250;
    }
    private void FixedUpdate()
    {
        if(lifespan <= 0)
        {
            Destroy(gameObject);
        }
        lifespan--;
    }
}
