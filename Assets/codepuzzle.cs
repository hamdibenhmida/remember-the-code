using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;
using TMPro;
using Random = UnityEngine.Random;

public class codepuzzle : MonoBehaviour
{
    const string alphabeticString = "0123456789"; //the code is generated from this string
    
    private string generatedCode; 

    [SerializeField] private int codeLength = 0;  // how many characters long for the code
    [SerializeField] private float waitForSeconds = 0; //used for coroutine
     
    [SerializeField] private TMP_Text Text; //the text that will show the player the code 
    [SerializeField] private TMP_InputField inputtext; //the text input field that the player will type the code

    
    private void Start()
    {
        inputtext.characterLimit = codeLength;
        GenerateCode();
    }

    public void GenerateCode ()
    {
        generatedCode = string.Empty;
        
        for (int i = 0; i < codeLength; i++)
        {
            generatedCode += alphabeticString[Random.Range(0, alphabeticString.Length)];
        }

        StartCoroutine(SetTextString(waitForSeconds) );
    }

    public IEnumerator SetTextString(float seconds) 
    {
        inputtext.gameObject.SetActive(false);
        
        Text.gameObject.SetActive(true);
        Text.text = generatedCode;
        yield return new WaitForSeconds(seconds);
        Text.gameObject.SetActive(false);
       
        inputtext.gameObject.SetActive(true);
    }

    public void CheckCode()
    {
        string code = inputtext.text;
        if (code == generatedCode)
        {
            generatedCode = "gg";
            StartCoroutine(SetTextString(5));
            inputtext.Select();
            inputtext.text = string.Empty;
        }
        else
        {
            generatedCode = "nice try";
            StartCoroutine(SetTextString(5));
            inputtext.Select();
            inputtext.text = string.Empty;
        }
    }


}
