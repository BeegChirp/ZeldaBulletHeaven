using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public LogicScript logic;
    public MenuScript menu;

    void Update()
    {
        if (Time.timeScale == 1)
        {
            transform.rotation = logic.aim(transform.position);
        }
    }
}
