using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    public static PuzzleManager instance;

    public bool isPuzzleOneFinished = false;
    public int puzzleTwoFixed = 0;
    public bool isPuzzleTwoFinished = false;



    #region Singleton
    private void Awake()
    {
        if(instance != null)
        {
            return;
        }

        instance = this;
    }
    #endregion

}
