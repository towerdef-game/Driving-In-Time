using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public GameManager manager;
//public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
      //  score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ObjectScore")
        {
           // Debug.Log("Collided");
           manager.score += 10;
         //   manager.targetsalive--;
        
            
        }
        
    }
}
