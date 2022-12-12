using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MakeInteractable : MonoBehaviour
{
    // Anything thats hidden will have its interaction turned off, in this case, if the keycard moves out of a trigger box, it becomes interactable. (Inside the toolbox)

    private void OnTriggerExit(Collider other)                  
    {
        GetComponent<XRGrabInteractable>().enabled = true;
    }
}
