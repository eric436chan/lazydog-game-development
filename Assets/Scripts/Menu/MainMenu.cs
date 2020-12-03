using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<LevelLoader>().LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
   
    public void LoadGame()
    {
        Debug.Log("This feature has not been added yet. Please wait for the dev team to finish this feature!");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
