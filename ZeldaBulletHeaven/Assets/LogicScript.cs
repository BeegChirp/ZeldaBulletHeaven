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
    public Transform playerTransform;
    public Vector2 attackRange = new Vector2(1, 1);
    public LayerMask enemyLayers = 9;
    public float angle;
    public int killCount = 0;
    public float bounceForce = 9;
    public float rightBounceForce = 9;
    float yTop = 25;
    float yBot = -25; 
    float zTop = 1;
    float zBot = -1;

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
        int damage = (int)Mathf.Round((data.Weapon[weapon, 0, player.currentLevel] + Random.Range(-2f, 2f)));
        bool crit = Random.Range(0, 100) < 30;
        if (crit) damage = (int)(Mathf.Round(damage*1.5f));
        health = health - damage;
        spawnDamageNumber(damage, enemyLocation); //get the damage ammount
        return health;
    }

    public void killCounter()
    {
        killCount++;
        Kills.text = "Kills: " + killCount.ToString();
    }

    public Vector3 followPlayer(int zDim)
    {
        Vector3 target = new Vector3(playerTransform.position.x, playerTransform.position.y, zDim);
        return target;
    }

    void spawnDamageNumber(int damage, Vector3 enemyLocation)
    {
        damageNumberText.text = damage.ToString();
        GameObject damageNumberPrefab = Instantiate(damageNumber, enemyLocation, Quaternion.identity);
        Rigidbody2D rb = damageNumberPrefab.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        if (enemyLocation.x - playerTransform.position.x >= 0)
        {
            rb.AddForce(Vector2.right * rightBounceForce, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.left * rightBounceForce, ForceMode2D.Impulse);
        }
    }

    public Vector3 zDepth(Vector3 pos)
    {
        float y = pos.y - playerTransform.position.y;
        if (y > 25) y = 25;
        if (y < -25) y = -25;
        return new Vector3 (pos.x, pos.y, Mathf.Lerp(zBot, zTop, Mathf.InverseLerp(yBot, yTop, y)));
    }

}


