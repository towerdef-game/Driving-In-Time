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
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speed = Random.Range(10, 15);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dist =  target.position-transform.position;

        if(dist.x<sightRadius || dist.z < sightRadius)
        {
            agent.speed = speed;
            agent.SetDestination(target.position);
        }
    }
}
