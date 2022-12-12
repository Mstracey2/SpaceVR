using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CardDisplay : MonoBehaviour
{
    #region Variables
                            //all the variables which connects the scriptable object to the card
    [SerializeField]
    private TMP_Text personName;       
    [SerializeField]
    private TMP_Text description;
    [SerializeField]
    private TMP_Text panicCode;
    [SerializeField]
    private Keycard card;
    [SerializeField]
    private GameObject photo;

    private Renderer rend;          //renderer ref for the photo
    #endregion

    // Start is called before the first frame update
    void Start()
    {
                                                        //changes the photo to the scriptable object material
        rend = photo.GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = card.photo;
                                                         //changes name, description and code
        personName.text = card.personName;             
        description.text = card.description;
        panicCode.text = card.panicCode;
    }
}
