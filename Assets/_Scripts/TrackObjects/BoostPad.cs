using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(BoxCollider))]
public class BoostPad : MonoBehaviour
{

    public BoxCollider box;
    public float boostStrength;

    public bool showDebug;

    void Awake()
    {
       // box = GetComponent<BoxCollider>();
    }
    void OnTriggerStay(Collider collider)
    {
        Racer racer = collider.gameObject.GetComponent<Racer>();
        
        if(racer != null)
        {
            Rigidbody car = racer.GetComponent<Rigidbody>();
            Vector3 carVector = car.velocity.normalized;
            car.AddForce(carVector * boostStrength, ForceMode.Force);
        }
        
    }

    void OnDrawGizmos()
    {
        if(showDebug)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(box.center, box.size);

        }

    }
}
