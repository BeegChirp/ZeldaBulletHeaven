using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    
    public PlayerScript player;
    public GameObject gameOverScreen;
    public EnemyScript enemy;
    public Vector2 attackRange = new Vector2(1,1);
    public LayerMask enemyLayers = 9;
    public float angle;

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void darknutDamage()
    {
        player.health --;
        player.immune = true;
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

    public void dealDamage() //int iFrames)
    {
        //if(enemy.iFrames <= 0)
        //{
            enemy.health --;
           // iFrames = 10;
        //}
        //return iFrames;
    }

    /*public int immunity(int iFrames)
    {
        if (iFrames > 0)
        {
            iFrames --;
        }
        return iFrames;
    }*/
}
