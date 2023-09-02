using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public LogicScript logic;
    void Update()
    {
        if (Time.timeScale == 1) //only rotate aimer if game is not paused
        {
            transform.rotation = logic.Aim(transform.position);
        }
    }
}
