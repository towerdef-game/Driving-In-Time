using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.ParticleSystemJobs;

public class power_Up_State : MonoBehaviour
{

    public enum powers_manage { nopower, speedup, blast, slowdown,pillar }
    public bool canpickup = true;

    public float pauseTime = 5f;
    public Timer timer;
    public float time;
    private Rigidbody rigid;
    public GameObject speedlight;
    public GameObject blastlight;
    public GameObject clocklight;
    public float boost;
    public GameObject Car;
    public GameObject boosters;
    public float radiusExplosion = 16f;
    public ParticleSystem explosion;
    public GameObject aruaeffect;
    public VisualEffect arua;
    public Vector4 green;
    public Vector4 blue; 
    public Vector4 red;
    public powers_manage _state;
    public bool fstperview;
  //  public GameObject[] ob;
    public ParticleSystem[] pillars;
    private void Start()
    {
        //  arua.GetVector4("color");
        rigid = GetComponent<Rigidbody>();
      
    }
    void Update()
    {

        switch (_state)
        {
            case powers_manage.nopower:
                canpickup = true;
                aruaeffect.SetActive(false);
                boosters.SetActive(false);
              if(fstperview == true)
                {
                    blastlight.SetActive(false);
                    speedlight.SetActive(false);
                    clocklight.SetActive(false);
                }
               
                break;
            case powers_manage.speedup:
                speedup();
                aruaeffect.SetActive(true);             
                arua.SetVector4("Color", blue);
                if (fstperview == true)
                {
                    speedlight.SetActive(true);
                }
                Debug.Log("hi from the speed up state");
                break;
            case powers_manage.blast:
                arua.SetVector4("Color", red);
                blast();               
                aruaeffect.SetActive(true);
                if (fstperview == true)
                {
                    blastlight.SetActive(true);
                }
                Debug.Log("hi from the blast state");
                break;
            case powers_manage.slowdown:
                arua.SetVector4("Color", green);
                slowdown();
                aruaeffect.SetActive(true);
                if (fstperview == true){
                    clocklight.SetActive(true);
                }
               
                Debug.Log("hi from the slow down state");
                break;
            case powers_manage.pillar:
                see();
                break;

        }

    }


    void see()
    {
  
        for (int i = 0; i < pillars.Length; i++)
        {
            pillars[i].Play();
        }
        _state = powers_manage.nopower;
    }
    void speedup()
    {
        canpickup = false;
        if (Input.GetKeyDown("e"))
        {
            rigid.AddForce(transform.forward * boost, ForceMode.Impulse);
            // StartCoroutine("boosttime", 2f);
            _state = powers_manage.nopower;
            boosters.SetActive(true);
            Debug.Log("speeding up");
        }
    }
    
    void blast()
    {
        canpickup = false;
        if (Input.GetKeyDown("e"))
        {

            Collider[] coll = Physics.OverlapSphere(transform.position, radiusExplosion);
            explosion.Play();
            for (int i = 0; i < coll.Length; i++)
            {
                if (coll[i].gameObject.GetComponent<TargetEnemy>())
                //if (coll[i].gameObject.tag == "Target")
                {
                    coll[i].gameObject.GetComponent<TargetEnemy>().TakeDamage();
                }
                else
                {
                    if(coll[i].gameObject.tag == "NonEnemy")
                    {
                        Destroy(coll[i].gameObject);
                    }
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
        //GetComponent<MeshRenderer>().enabled = false;
       // GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(pauseTime);
        //GameManager.GetComponent<Timer>().paused = false;
        //timer.paused = false;
        GameObject.FindObjectOfType<Timer>().paused = false;
        //Destroy(gameObject);

    }
}
