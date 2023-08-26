using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameOverCanvas;
    [SerializeField] private CanvasGroup theStuff;
    [SerializeField] private bool fadeIn = false;
    public GameObject gameOverScreen;
    public GameObject damageNumber;
    public TextMeshProUGUI Kills;
    public TextMeshPro damageNumberText;
    public EnemyScript enemy;
    public DataBase data;
    public PlayerScript player;
    public MusicLoop music;
    public Transform playerTransform;
    public Vector2 attackRange = new Vector2(1, 1);
    public LayerMask enemyLayers = 9;
    public float angle;
    public int killCount = 0;
    public float bounceForce = 9;
    public float rightBounceForce = 9;
    readonly float yTop = 25;
    readonly float yBot = -25;
    readonly float zTop = 1;
    readonly float zBot = -1;
    bool musicPlayed = false;
    public Quaternion Aim(Vector3 pos)
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - pos;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        return rotation;
    }
    public float DealDamage(float health, int weapon, Vector3 enemyLocation)
    {
        int damage = (int)Mathf.Round((data.Weapon[weapon, 0, player.currentLevel] + Random.Range(-2f, 2f)));
        bool crit = Random.Range(0, 100) < 30;
        if (crit) damage = (int)(Mathf.Round(damage * 1.5f));
        health -= damage;
        SpawnDamageNumber(damage, enemyLocation, crit); //get the damage ammount
        return health;
    }
    public Vector3 FollowPlayer(int zDim)
    {
        Vector3 target = new Vector3(playerTransform.position.x, playerTransform.position.y, zDim);
        return target;
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        fadeIn = true;
    }
    public void KillCounter()
    {
        killCount++;
        Kills.text = "Kills: " + killCount.ToString();
    }
    public void PlayerDamage(float damage)
    {
        player.health = player.health - damage;
        SpawnDamageNumber((int)damage, player.transform.position, false);
    }
    public void RestartGame()
    {
        fadeIn = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RestartTime()
    {
        Time.timeScale = 1f;
    }
    void SpawnDamageNumber(int damage, Vector3 location, bool crit)
    {
        damageNumberText.text = damage.ToString();
        if (crit)
        {
            damageNumberText.color = new Color32(255, 187, 0, 255);
            damageNumberText.fontStyle = FontStyles.Bold;
        }
        else
        {
            damageNumberText.color = new Color32(255, 255, 255, 255);
            damageNumberText.fontStyle = FontStyles.Normal;
        }
        GameObject damageNumberPrefab = Instantiate(damageNumber, location, Quaternion.identity);
        Rigidbody2D rb = damageNumberPrefab.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        if (location.x - playerTransform.position.x >= 0)
        {
            rb.AddForce(Vector2.right * rightBounceForce, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.left * rightBounceForce, ForceMode2D.Impulse);
        }
    }
    public Vector3 ZDepth(Vector3 pos)
    {
        float y = pos.y - playerTransform.position.y;
        if (y > 25) y = 25;
        if (y < -25) y = -25;
        return new Vector3(pos.x, pos.y, Mathf.Lerp(zBot, zTop, Mathf.InverseLerp(yBot, yTop, y)));
    }
    public void Update()
    {
        if (fadeIn)
        {
            if (musicPlayed == false)
            {
                music.YouDied();
                musicPlayed = true;
            }
            if (gameOverCanvas.alpha < 1)
            {
                gameOverCanvas.alpha += Time.deltaTime;
            }
            else
            {
                if (theStuff.alpha < 1)
                {
                    theStuff.alpha += (Time.deltaTime / 2);
                }
                else
                {
                    Time.timeScale = 0f;
                }
            }
        }
        else
        {
            gameOverCanvas.alpha = 0;
            theStuff.alpha = 0;
            musicPlayed = false;
        }
    }
}