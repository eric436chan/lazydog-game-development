using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    // Start is called before the first frame update
    private void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;

        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}