using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FMODUnity;
public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
   
    public float speed=10f;
    public float sightRadius;
    public float shootRadius;
    public float shotTime = 3;

    public GameObject enemyBullet;
    private Rigidbody enemy;

   public Vector3 range;


    //AudioSource enemySounds;
   public AudioClip siren, shoot, fly;

    public StudioEventEmitter enemySounds;
    void Start()
    {
       // enemySounds = GetComponent<AudioSource>();
        enemy = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        speed = Random.Range(10, 14);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //enemySounds.clip =siren;
      //  enemySounds.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dist =  target.position-transform.position;
        Vector3 minDist = target.position + target.position/10 - transform.position;
        shotTime -= 1 * Time.deltaTime;

        //if ((shootRadius > Mathf.Abs(dist.x) && Mathf.Abs(dist.z) < shootRadius) && shotTime < 0)
        //{
        agent.speed = speed;
        agent.SetDestination(target.position);
        RaycastHit hit;
        //if (Physics.Raycast(transform.position, target.position, out hit) && hit.transform.tag == "Player")
        //{
            //Debug.Log(hit.collider.name);
            transform.LookAt(target.position);
            if (shotTime <= 0)
            {
                Instantiate(enemyBullet, transform.position + new Vector3(0, 0, 2), Quaternion.identity);
                shotTime = 10f;
                    enemySounds.SetParameter("shooting", 1);
            }
        else enemySounds.SetParameter("shooting", 0);
        
        //} else enemySounds.SetParameter("shoot", 0);
            //} 
            //if (Mathf.Abs(dist.x) > shootRadius || Mathf.Abs(dist.z) > shootRadius)
            //{
                //agent.stoppingDistance use this 
                
            //}
        
       
        //    Debug.Log("cant run?" + Mathf.Abs(dist.x) + " is bigger than"+shootRadius + " and some how" + Mathf.Abs(dist.z) + " is smaller than" + shootRadius);
        
        // how can both if statements be running? 
   }
        

  
  
}
