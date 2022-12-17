using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KeypadController : MonoBehaviour
{
    #region Variables
    private float count = 0;
                                                                    
    [SerializeField] private AudioClip correctCodeSound;
    [SerializeField] private AudioClip incorrectCodeSound;
    private AudioSource inputSound;
    [SerializeField]
    private List<GameObject> ringCodes;                             // list of codes connected to the keycards, used to check what the player inputted was correct

    private TMP_Text display;
    [SerializeField]
    private SpecialKey Enter;                                       //Enter key, checks whether the the key was pressed
    [SerializeField]
    private SpecialKey Delete;                                      //Delete key, checks whether the the key was pressed

    private delegate void specialKeys();
    private specialKeys Special;
    private bool correctCode;
    #endregion

    private void Start()
    {
        display = GetComponent<TMP_Text>();
        inputSound = GetComponent<AudioSource>();
    }
    public void AddToCount(float number)                            //counter, stops the player from inputting more than 4 numbers
    {
        if(count != 4)
        {
            display.text = display.text + number;
            count++;
        }
    }

    public void CheckSpecialKeys()                                  //will call when either special key is pressed, delegate will change depending on what is pressed
    {
        if (Enter.pressed)
        {
            Special = EnterCode;
        }
        else if (Delete.pressed)
        {
            Special = ResetDisplay;
        }

        Special();                                                  //calls the delegate
    }

    public void ResetDisplay()
    {
        count = 0;
        display.text = "";
    }

    void EnterCode()
    {
        foreach(GameObject currentRing in ringCodes)                                //will check each code to see if the inputted number matches
        {
            correctCode = currentRing.GetComponent<ActivateRotation>().checkCode(display);
            if (correctCode)
            {
                break;
            }
        }

        if (correctCode)
        {
            inputSound.PlayOneShot(correctCodeSound);
        }
        else
        {
            inputSound.PlayOneShot(incorrectCodeSound);
        }

       
    }
}
