using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ending : MonoBehaviour
{
    public GameObject hole;
    public Image fadIn;
    public GameObject Button;
    // Start is called before the first frame update
    void Start()
    {
        fadIn.canvasRenderer.SetAlpha(0f);
        Button.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hole.SetActive(false);
            StartCoroutine("Fade");
        }

    }

    IEnumerator Fade()
    {
       // Debug.Log("Running");
        fadIn.CrossFadeAlpha(1, 8, false);
        //yield return new WaitForSeconds(8f);
        Button.SetActive(true);
        yield return new WaitForSeconds(44f);
        SceneManager.LoadScene(5);
    }

    public void ChangeScence()
    {
        SceneManager.LoadScene(5);
    }
}
