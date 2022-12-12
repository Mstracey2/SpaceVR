using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RevealCard : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject dispencer;
    [SerializeField] private GameObject conceledCard;
    [SerializeField] private string animationName;
    #endregion
    public void OpenBox()                                               // when the player completes the puzzle, he is rewarded with the keycard
    {
        dispencer.GetComponent<Animator>().Play(animationName);
        conceledCard.GetComponent<XRGrabInteractable>().enabled = true;
    }
}
