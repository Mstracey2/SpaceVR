using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KeyPress : MonoBehaviour
{
    [SerializeField]
    private int allocatedNumber;                    // number that the key is
    [SerializeField]
    private KeypadController controller;            //main keypad manager

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ButtonTrigger")
        {
            controller.AddToCount(allocatedNumber);         //displays the number that this key is allocated to
        }
    }
   
    
}
