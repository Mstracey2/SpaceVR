using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachScrew : MonoBehaviour
{
    #region Variables
    private float screwPos = 0;                 //starring position of screw
    private bool detached;                      //bool for whether the screw has detached
    private float finalPos = -0.005f;           //final destination before detatched

    private Rigidbody screwRig;
    #endregion

    #region Get component
    private void Start()
    {
        screwRig = GetComponent<Rigidbody>();
    }
    #endregion

    public void Detach()
    {
        if(detached == false)                                                                                                                            // if the screw has not been detached
        {
            screwPos = screwPos - 0.0001f;              
            transform.Rotate(0, -1000 * Time.deltaTime, 0, Space.Self);                                                                                  // rotates screw to give off effect of unscrewing
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + screwPos);          //moves position of screw outwards

            if (screwPos <= finalPos)                                                                                                                   // if the screw has come out far enough
            {
                transform.parent = null;                                                                                                                // screw detaches from the parent                                                                                               
                screwRig = gameObject.AddComponent<Rigidbody>();
                screwRig.useGravity = false;                                                                                                            // screw is now free and floats
                screwPos = 0f;
                detached = true;                                                                                                                        //screw is now detached

                
            }
        }
       
    }

    public bool CheckScrew()
    {
        return detached;
    }
}
