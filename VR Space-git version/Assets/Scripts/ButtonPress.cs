using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private RotateAroundPivot pivot;        //reference of the planets rotate script
    [SerializeField]
    private Vector3 axis;                   // the axis the planet rotates on
    #endregion

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "ButtonTrigger")     // if the button collides with the trigger
        {
            pivot.Rotate(axis);                 //rotates the planet on the given axis
        }
       
    }
}
