using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    protected Renderer rend;          //referenced renderer, used to switch mats
    protected Material objectMat;     //reference to original material
    [SerializeField]
    protected Material highlightMat;  //highlight colour

    protected void Start()
    {
        rend = GetComponent<Renderer>();     //gets renderer, used to change material
        objectMat = rend.sharedMaterial;    // sets the material to the original upon start
        rend.enabled = true;                //makes sure renderer is enabled
    }

    public void ChangeColour()          //changes material to highlight
    {
        rend.sharedMaterial = highlightMat;
    }

    public void OriginalColour()       //changes material back to original
    {
        rend.sharedMaterial = objectMat;
    }

    public void ChangeHighlightMat(Material newMat)         //changes the highlight material
    {
        objectMat = newMat;
    }
}
