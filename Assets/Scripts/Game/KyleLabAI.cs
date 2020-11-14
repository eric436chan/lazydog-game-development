using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KyleLabAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject dest;
    public Animator anim;


    // Start is called before the first frame update
    private void Start()
    {
        anim.SetBool("isTalking", false);
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        anim.SetBool("isWalking",true);
        FindObjectOfType<KyleDialogueTrigger>().enabled = false;
        agent.SetDestination(dest.transform.position);
    }
}