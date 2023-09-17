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
    int xpSpawn;
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
    private void Update()
    {
        if (xpSpawn > 0)
        {
            Instantiate(XP, player.transform);
            xpSpawn--;
        }
    }
    private void OnSpawnXP()
    {
        xpSpawn = 100;
    }
    private void OnHellMode()
    {
        hellMode = !hellMode;
    }
}
