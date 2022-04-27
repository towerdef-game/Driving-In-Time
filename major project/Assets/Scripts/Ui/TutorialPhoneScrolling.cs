using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPhoneScrolling : MonoBehaviour
{
    public float speed = 200f;
    public bool scroll = false;

    // Start is called before the first frame update

    void OnEnable()
    {
        scroll = true;
    }
    void Start()
    {

         speed = GetComponentInParent<Canvas>().transform.lossyScale.y * speed;
       // speed = GetComponentInParent<Canvas>().transform.* speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (scroll == true)
        {

            transform.Translate(0, speed * Time.deltaTime, 0);
        }
    }
}
