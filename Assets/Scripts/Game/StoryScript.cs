using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScript : MonoBehaviour
{
    public StoryDialogue storyDialogue;

    // Update is called once per frame

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StoryManager.instance.StartStory(storyDialogue);
        }
    }
}