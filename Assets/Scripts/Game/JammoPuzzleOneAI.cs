using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JammoPuzzleOneAI : MonoBehaviour
{

    PuzzleManager puzzleManager;
    NavMeshAgent agent;
    
    public GameObject dest;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        puzzleManager = PuzzleManager.instance;   
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleManager.isPuzzleOneFinished)
        {
            FindObjectOfType<JammoDialogueTrigger>().enabled = false;
            agent.SetDestination(dest.transform.position);
        }
    }
}
