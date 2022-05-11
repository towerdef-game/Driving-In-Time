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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Application.Quit();    
    }

    public void ReturnToMenu()
    {
        // currentScene--;
        Debug.Log("clicked");
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void restart()
    {
        Time.timeScale = 1;
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
}
