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

        if (shootRadius > dist.x  && shotTime < 0)
        {
            transform.LookAt(target.position);
            Instantiate(enemyBullet, transform.position + new Vector3(0, 0, 2), Quaternion.identity);
            shotTime = 5f;
        } else if ((dist.x<sightRadius &&  dist.x>shootRadius))
        {
            
            agent.speed = speed;
            agent.SetDestination(target.position);
        }

        if((dist.x > shootRadius && dist.z > shootRadius && shootRadius > dist.x && shootRadius > dist.z))
        {
            Debug.Log("cant run?" +dist.x+" is bigger than"+shootRadius + " and some how" + dist.x + " is smaller than" + shootRadius);
        }
        // how can both if statements be running? 
   }
        

  
  
}
