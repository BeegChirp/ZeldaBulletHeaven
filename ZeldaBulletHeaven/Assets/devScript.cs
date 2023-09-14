using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class devScript : MonoBehaviour
{
    public InputAction devCommands;

    private void OnEnable()
    {
        devCommands.Enable();
    }
    private void OnDisable()
    {
        devCommands.Disable();
    }
    void Update()
    {
        
    }
}
