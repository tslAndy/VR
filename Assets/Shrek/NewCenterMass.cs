using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCenterMass : MonoBehaviour
{
    [SerializeField] private Transform newCenterOfMass;
    private Rigidbody rb;
    private void Start()
    {
        rb.centerOfMass = newCenterOfMass.position;
    }
}
