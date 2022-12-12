using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR;
using UnityEngine.XR;

public class XRDevices : MonoBehaviour
{
    #region Variables
    public float handSpeed;
    [SerializeField]private Animator handAnim;
    [SerializeField]private GameObject hand;

    private InputDevice controller;                             //this is the ref to the input device, on start, it will attempt to detect the correct device
    public InputDeviceCharacteristics deviceType;               //ref to what device type it is

    // All of the float values used as guidence for the hand animations, current values and their targets
    private float gripCurrent;
    private float triggerCurrent;
    private float gripTarget;
    private float triggerTarget;

    //general components for the hand, turns on and off when grabbing items
    private BoxCollider handCol;
    private SphereCollider fingCol;
    private SkinnedMeshRenderer handMesh;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetDevices(1.0f));
        handCol = hand.GetComponent<BoxCollider>();
        fingCol = hand.GetComponentInChildren<SphereCollider>();
        handMesh = hand.GetComponentInChildren<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        Grip();
        Trigger();
        AnimateHand();
    }

    public IEnumerator GetDevices(float delayTime)      //the game waits before searching for devices, adds a safety buffer to have the controllers active before search.
    {
        yield return new WaitForSeconds(delayTime);


        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(deviceType, devices);        //gets devices of this type and adds it to a list, list should really only hold one device but could have errors if more try to connect


        if (devices.Count > 0)                                              //sets the focus device to the first device that connected
        {
            controller = devices[0];
        }
    }

    #region Device Inputs
    /*
     * Below is all of the Functions that are used to check whether the player is pressing a button or not
     * 
     * Some return simple yes or no bools, others return floats such as the trigger, as triggers can be slightly pressed
     * 
    */
    public bool TriggerPressed()
    {
        controller.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed);
        return triggerPressed;

    }

    public float Trigger()
    {
        controller.TryGetFeatureValue(CommonUsages.trigger, out float trigger);
        triggerTarget = trigger;
        return trigger;
        
    }

    public bool GripPressed()
    { 
        controller.TryGetFeatureValue(CommonUsages.gripButton, out bool gripPressed);
        return gripPressed;
    }

    public float Grip()
    {
        controller.TryGetFeatureValue(CommonUsages.grip, out float grip);
        gripTarget = grip;
        return grip;
    }
    #endregion

    public void AnimateHand()
    {
        if(gripCurrent != gripTarget)               
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * handSpeed);       //smooth motion of hand until its closed

            handAnim.SetFloat("GripF", gripCurrent);
        }
        if (triggerCurrent != triggerTarget)                                                            //same but for index and thumb
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * handSpeed);

            handAnim.SetFloat("TriggerF", triggerCurrent);
        }
    }


    #region Hand Toggle

    //these functions are used to toggle the hands on and off when they are grabbing an item, makes the game feel a bit more imersive.
    public void ToggleHandOn()
    {
        handCol.enabled = true;
        fingCol.enabled = true;
        handMesh.enabled = true;
    }

    public void ToggleHandOff()
    {
        handCol.enabled = false;
        fingCol.enabled = false;
        handMesh.enabled = false;
    }
    #endregion
}
