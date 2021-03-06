using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using FMODUnity;


public class GameManager : MonoBehaviour
{
    public GameObject portal;
    public float score = 0;
    public float specialpoints;
    public float speiclaunlock;
   public TextMeshProUGUI scoreText;
    public TextMeshProUGUI fpscoretext;
    public float targetsalive;
    public float NonEnemy = 0;
    public bool spawnEnemies = true;
    public GameObject enemyPrefab;
    public GameObject lose;
    public car_mk3 player;
    private bool canend = false;

    //gaint powerup 
    public static float powerUpTime = 10f;
    public Transform car;


    // scoretotal count
    float totalTargets;
    bool alive=true;


    //music
   
 
    private void Start()
    {
        score = 0;
        NonEnemy = 0;
      //  totalTargets = targetsalive*10;
     // Debug.Log(SceneManager.GetActiveScene().buildIndex+"this scene");
        //if()
       // int scene =SceneManager.GetActiveScene().buildIndex;
       
    }
    public void Endgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        scoreText.text ="Score: " + score.ToString() +"/"+totalTargets;
        fpscoretext.text = "Score: " + score.ToString() + "/" + totalTargets;
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


    public void LateUpdate()
    {

        if (alive)
        {
          totalTargets = targetsalive * 10;
            Debug.Log(totalTargets + " total" + targetsalive + "current");
            alive = false;
        }
        //if (targetsalive <= 0)
        //{
        //    alive = true;
        //}
        
    }


    //controlled using lists 

    public void OnSceneLoaded(Scene s, LoadSceneMode mode)
    {
      //  player.transform.position = GameObject.Find("PlayerSpawn").transform.position;
    }



    //save state
    // controlled using lists as the options
    //public List<Sprite> playerCars;


    public void SaveState()
    {

        string s = "";
        s += "0" + "|";
       // saving things like choices or numbers  s+=score.ToString()+"|"
        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {

        SceneManager.sceneLoaded -= LoadState;

        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change player skin
        
       
       

        Debug.Log("LoadState");
    }
    public void death()
    {
        // SceneManager.LoadScene("death");
        lose.SetActive(true);
        player.enabled = false;
    }
}
