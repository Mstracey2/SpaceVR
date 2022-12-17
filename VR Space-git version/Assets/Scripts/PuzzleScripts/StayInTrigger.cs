using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInTrigger : MonoBehaviour
{
    [SerializeField]private GameObject puzzleCollider;
    [SerializeField] private GameObject respawnPoint;

    //This is a saftey buffer for the AI controller, if the ball guide goes out of the trigger, it returns to start position on the board
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == puzzleCollider)
        {
            transform.position = respawnPoint.transform.position;
        }
    }
}
