using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPuzzleRaycast : MonoBehaviour
{
    // SCRIPT USED FOR THE PLANETS AND THE ORIGINAL LASER
    #region variables
    [SerializeField]
    protected GameObject origin;                        // this is a origin that determines what direction the planet or laser is raycasting
    private bool act = true;
    protected RaycastHit hit;
    protected LineRenderer lineRend;
    protected PlanetController nextRay;                 //ref to the script of a hit planet
    protected GameObject currentHitPlanet;              //ref to the planet game object
    #endregion

    // Start is called before the first frame update
    public void Start()
    {
        lineRend = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        updateLine();
        hit = RaycastObject(origin);
        if(hit.collider != null)
        {
            CheckRayCollision(hit, act);                    //function to check what the game should do with the hit infomation
        }
        lineRend.SetPosition(1, hit.point);                 //end of the line is the hit point
    }


    #region laser

    public RaycastHit RaycastObject(GameObject origin)
    {
        Physics.Raycast(origin.transform.position, origin.transform.forward, out RaycastHit hit);

        return hit;
    }

    public void updateLine()
    {
        lineRend.SetPosition(0, origin.transform.position);
        lineRend.SetPosition(1, origin.transform.position);
    }
    #endregion


    public void CheckRayCollision(RaycastHit obj, bool act)
    {
            if (obj.collider.tag == "Planet" && obj.collider.gameObject != gameObject && act) // if the hit is a planet, the hit is not itself and the laser is active
            {
                if(currentHitPlanet != null && obj.collider.gameObject != currentHitPlanet && nextRay != null)  // if there is a currently hit planet, the hit is a different planet to the currently hit one and the controller isn't null
                {
                     nextRay.ActivateAndDeactivate(false);                                                      //deactivate the originally current hit planet
                }

                currentHitPlanet = obj.collider.gameObject;                                                     // currently hit planet becomes the planet hit
                nextRay = obj.collider.gameObject.GetComponent<PlanetController>();
                nextRay.ActivateAndDeactivate(true);                                                            //activate the hit planet

            }
            else if (nextRay != null)                                                                           //if the ray has hit anything else, the controller is null
            {
                nextRay.ActivateAndDeactivate(false);
                nextRay = null;
            }
    }

   

}
