using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialKey : MonoBehaviour
{
    public KeypadController controller;
    public bool pressed;


    //simple trigger detection on keys, if pressed, bool turns to true. It will also call the controller to check which key it was that was pressed
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ButtonTrigger")
        {
            pressed = true;
            controller.CheckSpecialKeys();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ButtonTrigger")
        {
            pressed = false;
        }
    }
}
