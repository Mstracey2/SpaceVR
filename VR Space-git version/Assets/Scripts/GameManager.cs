using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private List<GameObject> hands = new List<GameObject>();                    // list of hands the player has, used to turn off its colliders and interactions on menu
    [SerializeField]
    private Countdown timer;                                                    
    [SerializeField]
    private List<GameObject> fXList = new List<GameObject>();                   // list of game failed special effects, will enable all of them when the player fails

    // used for enabling and disabling in menu
    private List<Collider> handColliders = new List<Collider>();                
    private List<Collider> handTriggers = new List<Collider>();                 
    private List<XRDirectInteractor> handInteractors = new List<XRDirectInteractor>(); 
    private Collider[] cols;
    private Collider[] trigs;

    public UnityEvent gameStartEvent;                                            // events for start and end of game, will have various listeners to play sequences.
    public UnityEvent gamePlayerFailedEvent;

    private bool gameOver;
    #endregion
    private void Start()
    {
        GetHandComponents();
    }

    private void Update()
    {
        if(timer.CheckTimer() <= 0 && gameOver == false)
        {
            PlayerFailed();
            gameOver = true;
        }
    }

    public void GameStart()
    {
        ChangeHandActivity();

        gameStartEvent.Invoke();
    }

    public void PlayerFailed()
    {
        gamePlayerFailedEvent.Invoke();
        ChangeHandActivity();

        foreach(GameObject fX in fXList)                                                // plays some special effects to show the player has failed and the ship is destroyed
        {
            fX.SetActive(true);
        }
    }

    public void GetHandComponents()                                                     //On start, the game will get all colliders for each hand so the game is able to turn them on and off when in the menu. Same for the XR Interactors.
    {
        foreach (GameObject thisHand in hands)
        {
            cols  = thisHand.GetComponentsInChildren<Collider>();
            trigs = thisHand.GetComponents<Collider>();

            foreach (Collider thisCol in cols)
            {
                handColliders.Add(thisCol);
            }
            foreach (Collider thisTrig in trigs)
            {
                handTriggers.Add(thisTrig);
            }

            handInteractors.Add(thisHand.GetComponent<XRDirectInteractor>());
        } 
    }

    public void ChangeTimer(bool newStatus)
    {
        timer.Active(newStatus);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeHandActivity()                                    //function that actually turns the colliders,triggers and interactors for the hands, used in menu
    {
        foreach (Collider thisHandCol in handColliders)
        {
            thisHandCol.enabled = !thisHandCol.enabled;
        }
        foreach (Collider thisHandTrig in handTriggers)
        {
            thisHandTrig.enabled = true;
        }
        foreach (XRDirectInteractor interactor in handInteractors)
        {
            interactor.enabled = !interactor.enabled;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
