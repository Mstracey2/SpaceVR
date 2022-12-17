using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private PuzzleManager manager;              // reference of the manager

    private GameObject playerRef;               //reference of the player's puzzlepiece
    private bool targetedDestination;           //bool to track if this destination is the targeted one
    public bool activated;                     //bool to check if this destination is activated

    private Light blinker;                      //reference to the point light connected to the destination
    private bool increaseIntensity = true;      //bool to make the light blink
    private float blinkDuration = 0;            //duration of blink
    private int intensityChanger = 0;           //value of the intensity
    #endregion

    private void Start()
    {
        blinker = (Light)GetComponentInChildren(typeof(Light));                 //gets light component from child

        foreach(GameObject moveable in manager.MoveableComponents)              //will check each puzzle piece until it finds the player, where the player is then referenced
        {
            if(moveable.tag == "Player")
            {
                playerRef = moveable;
                break;
            }
        }
    }

    private void Update()
    {
        if (targetedDestination)                //will make the blinker blink red
        {
            LightIntensity();
        }
        else if (activated)                     //will make the blinker a static blue
        {
            ActivatedLight();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == playerRef && targetedDestination == true)    //on collision with player and is the targeted destination
        {
            targetedDestination = false;
            activated = true;
            manager.ChangeTargetedDestination();                    //will change the target destination to the next on the list, this is no longer the target destination and is active
        }
    }

    #region Light Functions
    /*
     * these are functions used to change the light child,
     * light intensity is a process where the light will blink on and off in a red colour.
     * activated light makes the intensity still with a blue colour
     */
    private void LightIntensity()
    {
        float maxBlinkDuration = 100;           // sets the length of blink
        blinker.color = Color.red;              // sets the light to red

        if (increaseIntensity)                  // if the blinker is switched to on
        {
            if(blinkDuration >= maxBlinkDuration)   // if the duration is complete
            {
                increaseIntensity = false;          //switch blinker off
                intensityChanger = 0;               //change intensity
            }
            else
            {
                blinkDuration++;                // carry on counting
            }
            
        }
        else
        {
            if (blinkDuration <= 0)             // same as above but for off
            {
                increaseIntensity = true;
                intensityChanger = 1;
            }
            else
            {
                blinkDuration--;
            }
        }


        blinker.intensity = intensityChanger;
    }

    private void ActivatedLight()
    {
        blinker.color = Color.cyan;         //changes colour to a light blue
        blinker.intensity = 1;              //the light stays on
    }

    public void ResetLight()
    {
        blinker.intensity = 0;
    }

    #endregion

    #region Change values
    public void BeaconSwitch(bool switchb)
    {
        activated = switchb;
    }

    public void TargetSwitch(bool switchT)
    {
        targetedDestination = switchT;
    }
    #endregion

}
