using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public LogicScript logic;

    void Update()
    {
        transform.position = logic.followPlayer(-10);
    }
}
