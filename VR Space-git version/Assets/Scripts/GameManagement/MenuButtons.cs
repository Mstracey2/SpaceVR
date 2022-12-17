using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    private UnityEvent eventB;

    public void Pressed()
    {
        eventB.Invoke();
    }

}
