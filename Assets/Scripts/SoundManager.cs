using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource footStepInWater;

    [SerializeField]
    InputActionProperty m_LeftHandMoveAction;

    private void Update()
    {
        if (m_LeftHandMoveAction.action.ReadValue<Vector2>() != Vector2.zero)
        {
            footStepInWater.enabled = true;
        }
        else
        {
            footStepInWater.enabled = false;
        }
    }
}
