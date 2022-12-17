using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unscrew : MonoBehaviour
{
    private GameObject targetScrew;
    private DrillController drill;

    // Start is called before the first frame update
    void Start()
    {
        drill = GetComponentInParent<DrillController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetScrew != null && drill.DrillOn() == true)         //if there is a screw nearby and the drill is on
        {
            targetScrew.GetComponent<DetachScrew>().Detach();       //screw begins to unscrew
        }
    }

    // triggers will detect if there is a screw nearby the drill bit and assigns variable to that screw

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Screw")
        {
            targetScrew = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Screw")
        {
            targetScrew = null;
        }
    }
}
