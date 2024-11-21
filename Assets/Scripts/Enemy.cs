using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;

    private NavMeshAgent agent;
    private Transform target;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Arrow")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
