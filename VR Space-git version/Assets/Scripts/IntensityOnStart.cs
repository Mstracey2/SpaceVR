using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntensityOnStart : MonoBehaviour           //class is used on start to light up the room
{
    private Light thisLight;

    // Start is called before the first frame update
    void Start()
    {
        thisLight = GetComponent<Light>();
    }

    public void IncreaseIntensityOnStart()              // lights up the room the player is in on start
    {
        thisLight.intensity = 1;
    }

}
