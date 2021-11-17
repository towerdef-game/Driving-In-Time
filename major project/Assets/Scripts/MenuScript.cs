using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    int currentScene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public  void PlayButton()
    {
        currentScene++;
        SceneManager.LoadScene(currentScene);
    }
}
