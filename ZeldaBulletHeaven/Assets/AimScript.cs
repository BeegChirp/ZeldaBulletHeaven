using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public LogicScript logic;
    public MenuScript menu;

    void Update()
    {
        if (menu.pauseBool == false)
        {
            transform.rotation = logic.aim(transform.position);
        }
    }
}
