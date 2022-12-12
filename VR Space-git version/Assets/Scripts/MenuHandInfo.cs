using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandInfo : MonoBehaviour
{
    private LineRenderer lineRend;
    private XRDevices device;
    private RaycastHit rayHit;

    private MenuButtons selectButton;
    // Start is called before the first frame update
    void Start()
    {
        device = GetComponentInParent<XRDevices>();
        lineRend = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rayHit = RaycastObject();
        updateLine();

        if (rayHit.collider != null)
        {
            if (rayHit.collider.tag == "MenuButtons")                                   // if the ray hit is a menu button, it will reveal where the player is pointing with a line
            {
                lineRend.SetPosition(1, rayHit.point);
            }


            if (device.TriggerPressed() && rayHit.collider.gameObject.tag == "MenuButtons") // if the ray hit is a menu button, and the player pressed the trigger. it will do the function that the button is required for
            {
                selectButton = rayHit.collider.gameObject.GetComponent<MenuButtons>();
                selectButton.Pressed();
            }

        }
    }
    public RaycastHit RaycastObject()
    {
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hit);

        return hit;
    }

    public void updateLine()                                                //updates line to the transform as default
    {
        lineRend.SetPosition(0, transform.position);
        lineRend.SetPosition(1, transform.position);
    }

    
}
