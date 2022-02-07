using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class power_Up_State : MonoBehaviour
{

    public enum powers_manage { nopower, speedup, blast, slowdown }
    public bool canpickup = true;

    public float pauseTime = 5f;
    public Timer timer;
    public float time;

    public GameObject Car;
    public GameObject boosters;
    public float radiusExplosion = 16f;

    public GameObject aruaeffect;
    public VisualEffect arua;
    public Vector4 green;
    public Vector4 blue; 
    public Vector4 red;
    public powers_manage _state;
    private void Start()
    {
      //  arua.GetVector4("color");
    }
    void Update()
    {

        switch (_state)
        {
            case powers_manage.nopower:
                canpickup = true;
                aruaeffect.SetActive(false);
                boosters.SetActive(false);
                break;
            case powers_manage.speedup:
                speedup();
                aruaeffect.SetActive(true);
                arua.SetVector4("Color", blue);
                Debug.Log("hi from the speed up state");
                break;
            case powers_manage.blast:
                blast();
                aruaeffect.SetActive(true);
                arua.SetVector4("color", red);
                Debug.Log("hi from the blast state");
                break;
            case powers_manage.slowdown:
                slowdown();
                aruaeffect.SetActive(true);
                arua.SetVector4("color", green);
                Debug.Log("hi from the slow down state");
                break;


        }

    }



    void speedup()
    {
        canpickup = false;
        if (Input.GetKeyDown("e"))
        {
            StartCoroutine("boosttime", 2f);
            _state = powers_manage.nopower;
            boosters.SetActive(true);
            Debug.Log("speeding up");
        }
    }
     private IEnumerator boosttime(float time)
    {
        yield return StartCoroutine("");
    }
    void blast()
    {
        canpickup = false;
        if (Input.GetKeyDown("e"))
        {

            Collider[] coll = Physics.OverlapSphere(transform.position, radiusExplosion);

            for (int i = 0; i < coll.Length; i++)
            {
                if (coll[i].gameObject.GetComponent<TargetEnemy>())
                //if (coll[i].gameObject.tag == "Target")
                {
                    coll[i].gameObject.GetComponent<TargetEnemy>().TakeDamage();
                }
            }
            _state = powers_manage.nopower;

        }
    }

    void slowdown()
    {
        canpickup = false;
        if (Input.GetKeyDown("e"))
        {
            StartCoroutine(PickUp());
            Debug.Log("slowing down");
            _state = powers_manage.nopower;

        }
    }
    IEnumerator PickUp()
    {
        GameObject.FindObjectOfType<Timer>().paused = true;
        //GameManager.GetComponent<Timer>().paused = true;
        //timer = GameManager.GetComponent<Timer>();
        // timer.paused = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(pauseTime);
        //GameManager.GetComponent<Timer>().paused = false;
        //timer.paused = false;
        GameObject.FindObjectOfType<Timer>().paused = false;
        Destroy(gameObject);

    }
}
