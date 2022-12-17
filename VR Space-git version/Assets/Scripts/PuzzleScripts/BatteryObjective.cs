using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BatteryObjective : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject batteryRef;              //targeted battery
    [SerializeField]
    private  PuzzleManager puzzleManager;       //reference to the puzzle to be activated when the battery is placed
    private XRGrabInteractable batteryInteractable;     //used to deactivate the battery's interactable so the player cant move it when its in place
    private Highlight highlight;                    //used to deactivate highlight
    private Rigidbody batteryRig;                       //used to deactivate rigidbody, makes the battery lock into place
    #endregion

    public RevealCard card;

    #region Get Components
    private void Start()
    {
        batteryInteractable = batteryRef.GetComponent<XRGrabInteractable>();
        highlight = batteryRef.GetComponent<Highlight>();
        batteryRig = batteryRef.GetComponent<Rigidbody>();
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == batteryRef)             //if collider is the targeted battery
        {
            SnapToLocation();
        }
    }

    public void SnapToLocation()
    {

        batteryInteractable.enabled = false;        //locks the battery so the player or force can move it
        highlight.enabled = false;
        batteryRig.isKinematic = true;

        batteryRef.transform.position = transform.position;     //snaps the battery to the location of the objective
        batteryRef.transform.rotation = transform.rotation;

        puzzleManager.BeginPuzzle();                            //function to begin the referenced puzzle
    }
}
