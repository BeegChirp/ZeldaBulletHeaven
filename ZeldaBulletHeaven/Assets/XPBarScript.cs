using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBarScript : MonoBehaviour
{
    public PlayerScript player;
    public Slider slider;
    void Awake()
    {
        slider.value = player.xpProgress;
    }
    void Update()
    {
        slider.value = player.xpProgress;
    }
}
