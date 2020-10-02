using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusLevel : MonoBehaviour
{

    #region Singleton
    public static FocusLevel instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }
    #endregion

    [SerializeField] int focusLevel = 1;

    public int GetFocusLevel()
    {
        return focusLevel;
    }

    public void IncrementFocusLevel()
    {
        focusLevel++;
    }

}
