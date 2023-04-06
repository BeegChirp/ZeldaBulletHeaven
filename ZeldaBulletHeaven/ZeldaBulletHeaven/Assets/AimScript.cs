using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public LogicScript logic;

    void Update()
    {
        transform.rotation = logic.aim(transform.position);
    }
}
