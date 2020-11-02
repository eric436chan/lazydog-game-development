using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JammoPuzzleOneAI : MonoBehaviour
{
    private PuzzleManager puzzleManager;
    private NavMeshAgent agent;

    public GameObject dest;
    public Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        puzzleManager = PuzzleManager.instance;
    }

    // Update is called once per frame
    private void Update()
    {
        if (puzzleManager.isPuzzleOneFinished && JammoDialogueManager.instance.dialogueNumber == 4)
        {
            //agent.updatePosition = false;
            //agent.updateRotation = true;

             // and in your Update:
             anim.SetBool("isWalking", true);
             FindObjectOfType<JammoDialogueTrigger>().enabled = false;
            agent.SetDestination(dest.transform.position);
        }
        //anim.SetBool("isWalking", false);
    }
}