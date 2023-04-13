using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject damageNumber;
    public TextMeshProUGUI Kills;
    public TextMeshPro damageNumberText;
    public EnemyScript enemy;
    public DataBase data;
    public PlayerScript player;
    public Transform playerPos;
    public Vector2 attackRange = new Vector2(1, 1);
    public LayerMask enemyLayers = 9;
    public float angle;
    public int killCount = 0;
    public float bounceForce = 9;
    public float rightBounceForce = 9;

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

    public float dealDamage(float health, int weapon, Vector3 enemyLocation)
    {
        health = health - data.Weapon[weapon, 0, player.currentLevel];
        spawnDamageNumber(weapon, enemyLocation); //get the damage ammount
        return health;
    }

    public void killCounter()
    {
        killCount++;
        Kills.text = "Kills: " + killCount.ToString();
    }

    public Vector3 followPlayer(int zDim)
    {
        Vector3 target = new Vector3(playerPos.position.x, playerPos.position.y, zDim);
        return target;
    }
    
    void spawnDamageNumber(int weapon, Vector3 enemyLocation)
    {
        damageNumberText.text = data.Weapon[weapon, 0, player.currentLevel].ToString();
        GameObject damageNumberPrefab = Instantiate(damageNumber, enemyLocation, Quaternion.identity);
        Rigidbody2D rb = damageNumberPrefab.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        if (enemyLocation.x - playerPos.position.x >= 0)
        {
            rb.AddForce(Vector2.right * rightBounceForce, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.left * rightBounceForce, ForceMode2D.Impulse);
        }
    }

}


