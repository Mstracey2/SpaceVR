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
    private Animator dispenceAnim;
    private XRGrabInteractable cardInteractor;
    private HideCardCode cardCode;
    #endregion

    private void Start()
    {
        dispenceAnim = dispencer.GetComponent<Animator>();
        cardInteractor = conceledCard.GetComponent<XRGrabInteractable>();
        cardCode = conceledCard.GetComponent<HideCardCode>();
    }
    public void OpenBox()                                               // when the player completes the puzzle, he is rewarded with the keycard
    {
        dispenceAnim.Play(animationName);
        cardInteractor.enabled = true;                                  //sets the interaction to true, so the player can now grab the card
        cardCode.Show();                                                //reveals the code on the back
    }
}
