using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillController : MonoBehaviour
{
    #region Variables
    public XRDevices currentHand;      //tracks the current hand the drill is in
    [SerializeField]
    private GameObject drillBit;        //refrence to the drill point, used to spin the drill
    public bool activated;             //bool to check if drill has been triggered
    public bool Gripped;
    #endregion

    // Update is called once per frame
    void Update()
    {
        if(Gripped)            // if there is a hand attached and is gripped
        {
                if (currentHand != null && currentHand.TriggerPressed())                       // if the trigger is pressed on the controller
                {
                    activated = true;                                   // drill is activated
                    drillBit.transform.Rotate(0f, 0f , 1000 * Time.deltaTime, Space.Self);      //rotates drill bit
                }
                else
                {
                    activated = false;
                }
        }
        
    }


    #region triggers
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "HandTrigger" || !Gripped)                  //if the collider is the players hand
        {
            if(currentHand == null)           //if there is no hand already in area
            {
                currentHand = other.GetComponent<XRDevices>();              //the reference hand is changed
            }
           
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(currentHand != null)                         
        {
            if (other.gameObject == currentHand.gameObject)                 //if hand leaves area, set the current hand to null
            {
                currentHand = null;
            }
        }
    }

    #endregion

    #region Value checks
    public bool DrillOn()
    {
        return activated;
    }

    public void ChangeGrippedBool(bool grip)
    {
        Gripped = true;
    }

    public void GetCurrentHand(XRDevices device) { }

    #endregion
}
