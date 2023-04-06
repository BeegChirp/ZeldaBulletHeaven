using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    //public PlayerScript player;
    public GameObject gameOverScreen;
    public Text Kills;
    public EnemyScript enemy;
    public DataBase data;
    public PlayerScript player;
    public Vector2 attackRange = new Vector2(1, 1);
    public LayerMask enemyLayers = 9;
    public float angle;
    public int killCount = 0;

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void playerDamage(float damage)
    {
        player.health = player.health - damage;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public Quaternion aim(Vector3 pos)
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - pos;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        return rotation;
    }

    public float dealDamage(float health, int weapon) //int iFrames)
    {
        health = health - data.Weapon[weapon, 0, player.level];
        return health;
    }

    public void killCounter()
    {
        killCount++;
        Kills.text = killCount.ToString();
    }

}


