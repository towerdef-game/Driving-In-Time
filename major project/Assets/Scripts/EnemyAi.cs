using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
   
    public float speed=10f;
    public float sightRadius;
    public float shootRadius;
    public float shotTime;

    public GameObject enemyBullet;
    private Rigidbody enemy;
    void Start()
    {
        enemy = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        speed = Random.Range(10, 15);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dist =  target.position-transform.position;
        shotTime -= 1 * Time.deltaTime;
        if((dist.x<sightRadius || dist.z < sightRadius ) && (dist.x> shootRadius || dist.z>shootRadius))
        {
            Debug.Log("well okay then");
            agent.speed = speed;
            agent.SetDestination(target.position);
        }

        if((shootRadius>dist.x || shootRadius> dist.z)&& shotTime<0)
        {
            transform.LookAt(target.position);
         Instantiate(enemyBullet, transform.position+ new Vector3(0,0,2), Quaternion.identity);
            shotTime = 5f;
         }

        // how can both if statements be running? 
   }
        

  
  
}
