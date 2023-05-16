using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    [SerializeField] private GameObject leftTeleportation, rightTeleportation;
    [SerializeField] private InputActionProperty leftActive, rightActive;

    private void Update()
    {
        leftTeleportation.SetActive(leftActive.action.ReadValue<float>() > 0.1f);
        rightTeleportation.SetActive(rightActive.action.ReadValue<float>() > 0.1f);
    }
}
