using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ActivateRotation : MonoBehaviour
{
    #region variables
    [SerializeField]
    private TMP_Text assortedCode;                  // code which unlocks the ring, allowing the planet to rotate on a pivot
    [SerializeField]
    private GameObject planet;                      //reference of the planet

    private RotateAroundPivot rotater;              //reference of the script which rotates the planet
    private Highlight activeRing;               //script will change the colour of the ring when activated 

    #endregion

    #region Get Components
    private void Start()
    {
        activeRing = GetComponent<Highlight>();
        rotater = planet.GetComponent<RotateAroundPivot>();
    }
    #endregion

    public void ChangeColourAndActivate()           //function which will change the colour and also unlock the planet
    {
        rotater.Activate();
        activeRing.ChangeColour();
    }

    public bool checkCode(TMP_Text displayCode)     // useful function which checks if the inputted code from the keypad matches the assigned code.
    {
        if (displayCode.text == assortedCode.text)
        {
            ChangeColourAndActivate();
            return true;
        }
        else
        {
            return false;
        }
    }
}
