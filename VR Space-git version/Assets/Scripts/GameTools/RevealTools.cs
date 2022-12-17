using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RevealTools : MonoBehaviour
{
    public GameObject dispencer;
    public GameObject conceledObject;
    public string animationName;

    private Animator anim;
    private XRGrabInteractable Grab;

    private void Start()
    {
        anim = dispencer.GetComponent<Animator>();
        Grab = conceledObject.GetComponent<XRGrabInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand")
        {
            RevealTool();
        }
        
    }

    public void RevealTool()
    {
        anim.Play(animationName);
        Grab.enabled = true;
    }
}
