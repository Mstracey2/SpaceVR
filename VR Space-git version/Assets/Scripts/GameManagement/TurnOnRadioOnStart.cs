using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnRadioOnStart : MonoBehaviour
{
    //used at the on start of the game, turns radio on

    private AudioSource radio;
    private void Start()
    {
        radio = GetComponent<AudioSource>();
    }

    public void TurnOnRadio()
    {
        radio.Play();
    }
}
