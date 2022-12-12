using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : PlanetPuzzleRaycast
{

    // THIS IS SPECIFICALLY FOR THE PLANETS ONLY, THE ORIGINAL LASER USES JUST THE PlanetPuzzleRaycast

    private bool active = false;
    private Highlight colour;


    // Update is called once per frame
    void Update()
    {
        updateLine();
        hit = RaycastObject(origin);            //gets the infomation of a raycast from the origin of the planet angle
        CheckRayCollision(hit, active);         //will check the hit, will determine whether whatever is hit will be set to active
        
        

        if (active)
        {
            lineRend.SetPosition(1, hit.point);     //sets the line renderer to hit point
            colour = GetComponent<Highlight>();     //changes colour
            colour.ChangeColour();
        }
        else
        {
            colour = GetComponent<Highlight>();     //if not active, then the colour goes back to the original
            colour.OriginalColour();
        }
    }

    public void ActivateAndDeactivate(bool act)
    {
        active = act;
    }

    public GameObject CheckHit()
    { 
        if(hit.collider != null)
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    public bool CheckActive()
    {
        return active;
    }
}
