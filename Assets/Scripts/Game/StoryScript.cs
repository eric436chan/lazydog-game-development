using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScript : MonoBehaviour
{
    public CharacterController controller;
    private float dist;
    public StoryDialogue storyDialogue;

    // Update is called once per frame
    private void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, controller.transform.position);

        if (dist <= 3f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StoryManager.instance.StartStory(storyDialogue);
            }
        }
    }
}