using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.Rendering.DebugUI;

public class Sprint : MonoBehaviour
{
    [SerializeField]
    private float _sprintSpeed = 2;

    [SerializeField]
    private ContinuousMoveProviderBase m_continuousMoveProvider;

    [SerializeField]
    InputActionProperty m_LeftHandAction;

    private void Update()
    {
        if (m_LeftHandAction.action.ReadValue<bool>())
        {
            m_continuousMoveProvider.moveSpeed = _sprintSpeed;
        }
    }
}
