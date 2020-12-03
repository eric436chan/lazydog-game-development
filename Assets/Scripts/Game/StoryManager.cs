using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI storyText;
    public GameObject bookPanel;

    public bool isPaused;
    public static StoryManager instance;

    #region Singleton

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    #endregion Singleton

    public void Start()
    {
        bookPanel.SetActive(false);
    }

    public void StartStory(StoryDialogue storyDialogue)
    {
        dateText.text = storyDialogue.date;
        storyText.text = storyDialogue.story;
        FindObjectOfType<MouseLook>().enabled = false;
        FindObjectOfType<FirstPersonPlayer>().enabled = false;
        FindObjectOfType<PauseMenu>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        bookPanel.SetActive(true);
    }

    public void EndStory()
    {
        bookPanel.SetActive(false);
        FindObjectOfType<MouseLook>().enabled = true;
        FindObjectOfType<FirstPersonPlayer>().enabled = true;
        FindObjectOfType<PauseMenu>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}