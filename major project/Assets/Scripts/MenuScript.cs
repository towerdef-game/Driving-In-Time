using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    int currentScene;
    public GameObject menu;
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

    public void QuitButton()
    {

    }

    public void ReturnToMenu()
    {
        currentScene--;
        SceneManager.LoadScene(currentScene);
    }
    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
}
