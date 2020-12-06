using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsoleInput : MonoBehaviour
{
    public GameObject console;
    public GameObject inventoryPanel;
    public TextMeshProUGUI codeText;
    public Color originalColor;
    public bool isPaused;

    // Start is called before the first frame update
    private void Start()
    {
        console.SetActive(false);
        originalColor = codeText.color;
        isPaused = false;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Pause();
        }
    }

    public void CodeInput(string input)
    {
        if (codeText.text.Length < 8)
        {
            codeText.text += input;
        }
        else
        {
            return;
        }
    }

    public void CheckCode()
    {
        if (codeText.text.Equals("54311368"))
        {
            codeText.color = Color.green;
            StartCoroutine(CorrectCode());
        }
        else
        {
            codeText.color = Color.red;
            StartCoroutine(IncorrectCode());
        }
    }

    public void ClearCode()
    {
        codeText.text = "";
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<FirstPersonPlayer>().enabled = true;
        FindObjectOfType<MouseLook>().enabled = true;
        FindObjectOfType<PauseMenu>().enabled = true;
        codeText.text = "";
        console.SetActive(false);
        inventoryPanel.SetActive(true);
    }

    public void Pause()
    {
        inventoryPanel.SetActive(false);
        console.SetActive(true);
        FindObjectOfType<FirstPersonPlayer>().enabled = false;
        FindObjectOfType<MouseLook>().enabled = false;
        FindObjectOfType<PauseMenu>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        codeText.text = "";
    }

    private IEnumerator IncorrectCode()
    {
        yield return new WaitForSeconds(0.5f);
        codeText.text = "";
        codeText.color = originalColor;
    }

    private IEnumerator CorrectCode()
    {
        yield return new WaitForSeconds(0.5f);
        KyleDialogueManager.instance.dialogueNumber = 7;
        Resume();
    }
}