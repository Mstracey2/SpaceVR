using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedCollum : MonoBehaviour
{
    #region Variables
    [SerializeField] bool correctCollum;                  //bool to determine if this is the one of a list of correct collums
    [SerializeField] private BallGameManager puzzleManager;
    private GameObject ball;
    #endregion

    #region Triggers
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball" && correctCollum && ball == null)      //if collider is a ball/mine and is correct
        {
            ball = other.gameObject;
            puzzleManager.ChangeCorrect(1);                     //adds to the correct value in the manager
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball" && correctCollum && other.gameObject == ball)     //deactivates if mine/ball leaves trigger
        {
            puzzleManager.ChangeCorrect(-1);
            ball = null;
        }
    }
    #endregion


}
