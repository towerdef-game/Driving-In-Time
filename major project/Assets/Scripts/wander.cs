using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wander : MonoBehaviour
{
    public NavMeshAgent agent;
    [Range(0, 100)] public float speed;
    [Range(1,500)] public float walkradius;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent != null)
        {
            agent.speed = speed;
            agent.SetDestination(randomnavmeshlocation());
        }
         
    }
    

    public Vector3 randomnavmeshlocation()
    {
        Vector3 finalpositon = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkradius;
        randomPosition += transform.position;
        if(NavMesh.SamplePosition(randomPosition,out NavMeshHit hit,walkradius,1))
        {
            finalpositon = hit.position;
        }
        return finalpositon;
    }

    // Update is called once per frame
    void Update()
    {
      if(agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(randomnavmeshlocation());
        }  
    }
}
