using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarScript : MonoBehaviour
{
    public PlayerScript player;
    public Slider slider;
    void Awake()
    {
        slider.maxValue = player.maxHealth;
        slider.value = player.health;
    }
    void Update()
    {
        slider.maxValue = player.maxHealth;
        slider.value = player.health;
    }
}
