using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KyleLabAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject dest;

    // Start is called before the first frame update
    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        FindObjectOfType<KyleDialogueTrigger>().enabled = false;
        agent.SetDestination(dest.transform.position);
    }
}