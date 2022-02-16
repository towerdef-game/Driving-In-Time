using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchcamera : MonoBehaviour
{
    public bool firstperson = false;
    public GameObject povcam;
    public GameObject thirdperson;
    public GameObject firstpersonui;
    public GameObject thirdpersonui;
    // Start is called before the first frame update
    public void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            camswitch();
            Debug.Log("f key pressed");
        }
    }

    public void camswitch()
    {
        if (firstperson == false)
        {
           povcam.SetActive(true);
            thirdperson.SetActive(false);
            firstpersonui.SetActive(true);
            thirdpersonui.SetActive(false);
            firstperson = true;

        } else if(firstperson == true)
        {
            povcam.SetActive(false);
            thirdperson.SetActive(true);
            firstpersonui.SetActive(false);
            thirdpersonui.SetActive(true);
            firstperson = false;
        }

    }
}
