using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideCardCode : MonoBehaviour
{
    [SerializeField] private GameObject code;

    //this is simply designed to hide the code, stops the player from cheating by looking through the walls
    //required to be in a script as the code is assigned on the start of game, so it will hide codes once the code has been assigned
    public void hide()
    {
        code.SetActive(false);
    }

    public void Show()
    {
        code.SetActive(true);
    }
}
