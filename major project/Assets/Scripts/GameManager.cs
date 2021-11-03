using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public float score = 0;
    public float specialpoints;
    public float speiclaunlock;
   public TextMeshProUGUI scoreText;
    public float targetsalive;
    public float scoreNonEnemy = 0;
    public bool spawnEnemies = true;
    public GameObject enemyPrefab;
    private void Start()
    {
        score = 0;
        scoreNonEnemy = 0;
    }
    public void Endgame()
    {

    }
    private void FixedUpdate()
    {
       
       //scoreText.text = "Score: " + score;
        scoreText.text = score.ToString();
    }
    public void Update()
    {
        if(specialpoints >= speiclaunlock)
        {
            //do something
        }
    if(targetsalive <= 0)
        {
            Endgame();
            Debug.Log("noenemies");
        }

    if(scoreNonEnemy >= 5 && spawnEnemies ==  true)
        {
            
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            scoreNonEnemy = 0;


            spawnEnemies = false;
        }

     if(scoreNonEnemy <= 5)
        {
            spawnEnemies = true;
        }
    }
}
