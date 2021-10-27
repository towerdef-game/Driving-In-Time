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
  
    private void Start()
    {
        score = 0;
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
    }
}
