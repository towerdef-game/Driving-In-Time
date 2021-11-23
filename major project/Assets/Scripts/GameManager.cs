using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject portal;
    public float score = 0;
    public float specialpoints;
    public float speiclaunlock;
   public TextMeshProUGUI scoreText;
    public float targetsalive;
    public float NonEnemy = 0;
    public bool spawnEnemies = true;
    public GameObject enemyPrefab;

    private bool canend = false;


    public static float powerUpTime = 10f;
    public Transform car;
    private void Start()
    {
        score = 0;
        NonEnemy = 0;
    }
    public void Endgame()
    {
         SceneManager.LoadScene(1);
    //    Debug.Log("noenemies");
    }
    private void FixedUpdate()
    {
        //gaintmode
        if (GaintMode.gaintMode == true && powerUpTime > 0)
        {
            powerUpTime -= 1 * Time.deltaTime;
        }
        else if (powerUpTime < 0 && GaintMode.gaintMode != false)
        {
            GaintMode.gaintMode = false;
            car.localScale = new Vector3(1, 1, 1);
            GaintMode.speed.speed /= 5;
        }

        //scoreText.text = "Score: " + score;
        scoreText.text ="Score: " + score.ToString();
    }
    public void Update()
    {

       




        if(specialpoints >= speiclaunlock)
        {
            //do something
        }
    if(targetsalive <= 0)
        {
            //    Endgame();
            //    Debug.Log("noenemies");
            portal.SetActive(true);
            canend = true;
        }

    if(NonEnemy >= 5 && spawnEnemies ==  true)
        {
            
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            NonEnemy = 0;


            spawnEnemies = false;
        }

     if(NonEnemy <= 5)
        {
            spawnEnemies = true;
        }
    }
}
