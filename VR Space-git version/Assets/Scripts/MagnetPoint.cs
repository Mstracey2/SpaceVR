using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPoint : MonoBehaviour
{
    public float force = 200f;

    private List<Rigidbody> grabbedObjects = new List<Rigidbody>();

    private Transform MagnetTransform;
    // Start is called before the first frame update
    void Start()
    {
        MagnetTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        foreach(Rigidbody obj in grabbedObjects)
        {
            obj.AddForce((MagnetTransform.position - obj.position) * force * Time.deltaTime);   // sucks the objects in the area towards the magnet point
        }
    }

            // TRIGGERS: Used to grab any rigidbodies in the area, will only work with gameobjects with the tag "Ball"

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            grabbedObjects.Add(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            grabbedObjects.Remove(other.GetComponent<Rigidbody>());
        }
    }
}
