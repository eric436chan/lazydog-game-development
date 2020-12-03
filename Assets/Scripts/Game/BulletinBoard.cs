using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletinBoard : MonoBehaviour
{
    public Animator fadeAnim;
    public int puzzleCharacter;
    public TextMeshProUGUI fadingText;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (puzzleCharacter)
            {
                case 4:
                    fadingText.text = "Q=5 I=3";
                    break;

                case 3:
                    fadingText.text = "T=1 N=6";
                    break;

                case 2:
                    fadingText.text = "U=I+T";
                    break;

                case 1:
                    fadingText.text = "G=Q+I";
                    break;
            }
            fadeAnim.Play("Out");
        }
    }
}