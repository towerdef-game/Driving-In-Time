using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    
    
        public float timeRemaining = 10;
    public GameManager manager;
        public bool Running = false;
        public bool paused = false;
    //public Text timeText;
    public TextMeshProUGUI timeText;

        private void Start()
        {
            // Starts the timer automatically
            Running = true;
            paused = false;
        }

        void Update()
        {
            if (Running && !paused)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
                else
                {
                   
                    timeRemaining = 0;
                    Running = false;
                     manager.Endgame();
                }
            }
        }

        void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
}

