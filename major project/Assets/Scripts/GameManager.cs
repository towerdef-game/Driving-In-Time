using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
       
    }
    public void Endgame()
    {

    }
    private void FixedUpdate()
    {
        scoreText.text = "Score: " + score;
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
