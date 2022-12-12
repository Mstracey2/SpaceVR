using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[CreateAssetMenu(fileName = "New Keycard", menuName = "Card")]
public class Keycard : ScriptableObject
{
    // variables for the keycards, stored inside scriptable objects
    public string personName;
    public string description;
    public Material photo;
    public string panicCode;
}
