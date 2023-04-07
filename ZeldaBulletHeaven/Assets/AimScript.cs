using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public LogicScript logic;

    void Update()
    {
        transform.rotation = logic.aim(transform.position);
        //transform.position = new Vector3(transform.positon.x, transform.position.y, -9);
        //Debug.Log(Input.mousePosition);
    }
}
