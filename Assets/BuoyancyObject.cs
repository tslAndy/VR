using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class BuoyancyObject : MonoBehaviour
{


    public float underWaterDrag = 3;
    public float underWaterAngularDrag = 1;
    public float airDrag = 0;
    public float airAngularDrag = 0.05f;

    public float floatingSpeed = 4f;
    public float floatUpSpeedLimit = 1.15f;

    Rigidbody rb;

    Collider newWaterCollider;
   

    bool underwater;
   private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            newWaterCollider = other.GetComponent<Collider>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 4 && newWaterCollider != null)
        {
            float difference = ((other.transform.position.y + newWaterCollider.bounds.extents.y)
                - this.transform.position.y) * floatingSpeed;
            rb.AddForce(new Vector3(0f,
                Mathf.Clamp((Mathf.Abs(Physics.gravity.y) * difference), 0, Mathf.Abs(Physics.gravity.y) * floatUpSpeedLimit),
                0f), ForceMode.Acceleration);
            rb.drag = underWaterDrag;
            rb.angularDrag = underWaterAngularDrag;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            rb.drag = airDrag;
            rb.angularDrag = airAngularDrag;
        }
    }
}

