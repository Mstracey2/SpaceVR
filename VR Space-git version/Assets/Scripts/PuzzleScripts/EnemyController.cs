using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : PuzzlePieces
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == target)                  //if the enemy reaches its destination, the puzzle is reset
        {
            Manager.ResetPuzzle();
        }
    }
}
