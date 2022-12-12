using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DetachScrewedObject : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private List<DetachScrew> screws;           //list of screws attached to the object
    [SerializeField]
    private GameObject attached;                //reference to the attached transform
    [SerializeField]
    private GameObject attachedTo;              //reference to the object the battery is attached to (radio)

    private float screwsDetached = 0;           //counter to count how many screws are detached
    private bool detached;                      //bool for for the detachment of the battery

    private MeshCollider batteryCollider;       //enables the collider of the battery once detached, this is required otherwise the player can pull the battery off the radio without detaching the screws
    private Rigidbody batteryRig;               //makes the battery interactable
    private AudioSource radioSound;             //used to mute the radio
    #endregion

    #region Get components
    // Start is called before the first frame update
    void Start()
    {
        batteryCollider = gameObject.GetComponent<MeshCollider>();
        batteryRig = gameObject.GetComponent<Rigidbody>();
        radioSound = attachedTo.GetComponent<AudioSource>();
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        CheckScrews();                  //checks the status of each screw
       
        if (screwsDetached == screws.Count && detached == false)        //if all screws are detached and the battery is not detached yet
        {
            detached = true;                                            //the battery is detached
            batteryCollider.enabled = true;                             //collider is enabled
            batteryRig.isKinematic = false;                             //no longer kinematic
            radioSound.mute = true;                                     //mutes radio
            enabled = false;                                            //disables the script, the script is no longer required so it can be disabled. This stops the game from checking pointless updates.

        }
        else
        {
            transform.position = attached.transform.position;           //if the battery is still attached, then the transform stays attached
            transform.rotation = attached.transform.rotation;
        }

    }

   public void CheckScrews()
    {
        screwsDetached = 0;

        foreach (DetachScrew screw in screws) // goes through each screw in the list to check if the screws are detached
        {
            if (screw.CheckScrew())
            {
                screwsDetached++;
            }

        }

       
    }
}
