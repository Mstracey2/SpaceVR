using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnStart : MonoBehaviour
{
    private Camera cam;
    private void Start()
    {
       cam = GetComponent<Camera>();
    }

    public void IncreaseClippingPlanes()            // when the game is started, this will reveal the outside area of the game.
    {
        cam.farClipPlane = 10000;
    }
}
