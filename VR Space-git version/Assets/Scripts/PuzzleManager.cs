using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    #region Variables
    public List<GameObject> MoveableComponents;
    public List<GameObject> destinations;
    [SerializeField] private RevealCard cardStorage;                //keycard storage box, will open when puzzle is complete
    private int destinationCount = 0;
    #endregion

    #region Puzzle status
    public void ResetPuzzle()
    {
        foreach( GameObject movable in MoveableComponents)          // returns all movable components back to their starting position
        {
            movable.GetComponent<PuzzlePieces>().myAgent.Warp(movable.GetComponent<PuzzlePieces>().originalPosition);
        }
        foreach (GameObject destination in destinations)            // sets all destinations back to the starting condition
        {
            DestinationController thisDes = destination.GetComponent<DestinationController>();
            thisDes.BeaconSwitch(false); 
            thisDes.TargetSwitch(false);
            thisDes.ResetLight();

        }

        BeginPuzzle();                                              //begins puzzle again
    }
    public void BeginPuzzle()
    {
        destinationCount = 0;
        destinations[destinationCount].GetComponent<DestinationController>().TargetSwitch(true);        // first of the destinations is target

        foreach (GameObject movable in MoveableComponents)          //activates all moving components
        {
            movable.GetComponent<PuzzlePieces>().activate();
        }


    }

    public void PausePuzzle()
    {
        foreach (GameObject movable in MoveableComponents)              //simply stops moving components
        {
            movable.GetComponent<PuzzlePieces>().myAgent.isStopped = true;
        }
    }
    #endregion

    public void ChangeTargetedDestination()                         //function is called from destinations if player reaches the target
    {
        destinationCount++;

        if(destinationCount == destinations.Count)                  // if player has reached all destinations
        {
            cardStorage.OpenBox();                                  //open the keycard storage
            PausePuzzle();
        }
        else
        {
            destinations[destinationCount].GetComponent<DestinationController>().TargetSwitch(true);        //if not, the next destination in line becomes the target destination for the player
        }
    }

   
        
}
