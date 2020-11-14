using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JammoPuzzleTwoAI : MonoBehaviour
{
    private PuzzleManager puzzleManager;
    private NavMeshAgent agent;
    public Animator anim;
    public GameObject dest;

    // Start is called before the first frame update
    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        puzzleManager = PuzzleManager.instance;
    }

    // Update is called once per frame
    private void Update()
    {
        if (puzzleManager.puzzleTwoFixed == 3)
        {
            FindObjectOfType<JammoDialogueTrigger>().enabled = false;
            agent.SetDestination(dest.transform.position);
            anim.SetBool("isWalking", true);
        }
    }
}