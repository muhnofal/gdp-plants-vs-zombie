using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogScript : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject panel, pointer;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        //Panel
        if(textDisplay.text == sentences[index])
        {
            panel.SetActive(true);
            continueButton.SetActive(true);
        }
        else if(textDisplay.text == "")
        {
            panel.SetActive(false);
            
        }

        //Pointer
        if (textDisplay.text == "Tekan Tanaman!")
        {
            pointer.SetActive(true);
        }
        else if (textDisplay.text == "")
        {
            pointer.SetActive(false);
        }

    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }



    }

}
