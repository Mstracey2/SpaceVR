using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPivot : MonoBehaviour
{
    [SerializeField]
    private GameObject pivotPoint;                          //the sun

    [SerializeField]
    private CopyBoard outerEnviroment;                      // this is the Bigger planet outside, it will copy what the board version's position is

    private float speed = 25;
    private bool active = false;

    
    public void Activate()
    {
        active = true;
    }

    public void Rotate(Vector3 axis)                                                                // planet rotates around the sun, used in the planet puzzle. 
    {
        if (active)
        {
            transform.RotateAround(pivotPoint.transform.position, axis, speed * Time.deltaTime);
            outerEnviroment.Copy(axis, speed);
        }
        
    }

}
