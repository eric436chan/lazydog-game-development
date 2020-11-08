using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoryDialogue
{
    public string date;

    [TextArea(10, 10)]
    public string story;
}