using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JammoLabAI : MonoBehaviour
{
    private NavMeshAgent agent;

    public GameObject dest;
    public Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        anim.SetBool("isWalking", true);
        FindObjectOfType<JammoDialogueTrigger>().enabled = false;
        agent.SetDestination(dest.transform.position);
    }
}