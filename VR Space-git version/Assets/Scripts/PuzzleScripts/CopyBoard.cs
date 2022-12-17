using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyBoard : MonoBehaviour
{

    [SerializeField]
    private GameObject sun;             //ref of the pivot location


    public void Copy(Vector3 axis, float speed)     //copies the puzzle inside the XR Room
    {
        transform.RotateAround(sun.transform.position, new Vector3(0,axis.x,0), speed * Time.deltaTime);
    }
}
