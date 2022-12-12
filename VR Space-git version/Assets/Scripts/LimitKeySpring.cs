using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitKeySpring : MonoBehaviour
{
    private SpringJoint spring;

    private void Start()
    {
        spring = GetComponent<SpringJoint>();
    }
    // Update is called once per frame
    void Update()
    {
            if (transform.position.x < spring.connectedAnchor.x)                // if the x position goe beyond the anchor on the x axis, then it keeps the key still. This stops the spring bouncing back and fourth when pressed and only goes in one direction
            {
                transform.position = reset();
            }
    }

    public Vector3 reset()
    {
            return new Vector3(spring.connectedAnchor.x, transform.position.y, transform.position.z);           //resets position to anchor
    }

    
}
