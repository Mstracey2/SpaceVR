using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PuzzlePieces : MonoBehaviour
{
    #region variables
    public Vector3 originalPosition;                                           //position to reset to
    private bool wake;
    [SerializeField]protected GameObject target;                               // target the moving piece goes to
    public NavMeshAgent myAgent;
    protected PuzzleManager Manager;
    #endregion
    public void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        originalPosition = transform.position;
        
    }

    private void Update()
    {
        if (wake)                                                             // if the movable piece is awake, it will move to target
        {
            Move();
        }
    }

    public void Move()
    {
      myAgent.SetDestination(target.transform.position);                //heads towards target
    }

    public void activate()
    {
        wake = true;
    }
}
