using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RayPuzzleManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private List<PlanetController> planets = new List<PlanetController>();
    [SerializeField]
    private PlanetController lastPlanet;            // the last planet is the planet which will directly raycast onto the sun, the final part of the puzzle
    [SerializeField]
    private GameObject laser;                       // the laser is the origin of the red line, the beginning laser
    private PlanetPuzzleRaycast laserRaycast;       // original laser raycast script
    [SerializeField]
    private UnityEvent endEvent;                    // this end event will be called if the game is completed, it calls the end of the game and is the final action
    [SerializeField]
     private GameManager manager;

    private LineRenderer laserLine;
    private RaycastHit hit;
    private Highlight sunhighlight;
    private bool allPlanetsActivated = false;
    private bool lastplanetHittingSun;              //checks to see if the correct planet is hitting the sun, if so the event will start
    private Animator anim;                          //animation of the puzzle moving off the window
    private AudioSource victorySound;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        sunhighlight = GetComponent<Highlight>();
        laserLine = laser.GetComponent<LineRenderer>();
        laserRaycast = laser.GetComponent<PlanetPuzzleRaycast>();
        victorySound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(PlanetController planet in planets) //checks to see if all planets are active, a way of guarentee that the player has done the puzzle correctly
        {
            if (planet.CheckActive())
            {
                allPlanetsActivated = true;
            }
            else
            {
                allPlanetsActivated = false;            //if one is not active, the loop breaks so the game knows that the puzzle is not complete
                break;
            }
        }

        if (lastPlanet.CheckHit() == this.gameObject && lastPlanet.CheckActive())               //if the last planet is hitting the sun and is active
        {
           lastplanetHittingSun = true;
        }
        else
        {
            lastplanetHittingSun = false;
        }

        if (lastplanetHittingSun && allPlanetsActivated)                    //if all values are true, this is the ending result
        {
            sunhighlight.ChangeColour();                                    //changes material to a green as a indication that its hit
            laserRaycast.enabled = false;                                   // turns off the laser
            laserLine.SetPosition(0, laser.transform.position);             // the line render positions are the same to hide the line
            laserLine.SetPosition(1, laser.transform.position);
            manager.ChangeTimer(false);                                     //timer is stopped
            anim.enabled = true;                                            //plays ending animation
            anim.Play("EndGameAnimation");
            endEvent.Invoke();
            victorySound.Play();
            foreach(PlanetController thisPlanet in planets)
            {
                thisPlanet.ActivateAndDeactivate(false);
            }
        }
    }
}
