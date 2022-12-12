using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallGameManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private List<GameObject> ballList;               //list of the amount of balls

    private float correct = 0;                      //float which keeps track of all the balls in the correct positions

    [SerializeField]
    private GameObject card;                        //card that the player recives from completing the puzzle
    private Animator cardAnim;                      //animation of the card coming out of the slot
    private XRGrabInteractable cardInteractable;    //reference to the XR interactable, used to enable the interactable. (stops the player form being able to grab it without completing the puzzle)
    private Rigidbody cardRigidbody;                //reference to disable isKinimatic
    #endregion

    #region Get Components
    // Start is called before the first frame update
    void Start()
    {
        cardAnim = card.GetComponent<Animator>();
        cardInteractable = card.GetComponent<XRGrabInteractable>();
        cardRigidbody = card.GetComponent<Rigidbody>();
    }
    #endregion

    // Update is called once per frame
    private void Update()
    {
       if(correct == ballList.Count)                //if all balls are in the correct positions
        {
            cardAnim.Play("BillCardMove");          //plays animation
            StartCoroutine(OnAnimationEnd());       //this coroutine makes the card become interactable, it will wait a certain amount of time beforehand for the animation to finish
        }
    }

   private IEnumerator OnAnimationEnd()
    {
        yield return new WaitForSeconds(1.5f);      //waits for animation to end

        cardInteractable.enabled = true;            //makes card interactable
        cardRigidbody.isKinematic = false;

        yield break;

    }

                                                    //used to change the value of trigger variables
    #region Change values                
    public void ChangeCorrect(float value)
    {
        correct += value;
    }
    
    #endregion
}
