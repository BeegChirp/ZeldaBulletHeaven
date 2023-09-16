using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class devScript : MonoBehaviour
{
    public PlayerControls playerControls;
    public InputAction devCommands;
    public GameObject XP;
    public GameObject player;
    public bool hellMode = false;
    private void OnEnable()
    {
        devCommands.Enable();
    }
    private void OnDisable()
    {
        devCommands.Disable();
    }
    private void Start()
    {
        playerControls = new PlayerControls();
    }
    private void OnSpawnXP()
    {
        for (int xp = 0; xp < 100; xp++)
        {
            Instantiate(XP, player.transform);
        }
    }
    private void OnHellMode()
    {
        hellMode = !hellMode;
    }
}
