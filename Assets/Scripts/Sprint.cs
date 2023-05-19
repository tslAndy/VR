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

    private bool _sprintPressed;

    private float _initialSpeed;

    private void Start()
    {
        _initialSpeed = m_continuousMoveProvider.moveSpeed;

        m_LeftHandAction.action.performed += (InputAction.CallbackContext _) => { _sprintPressed = true; };
        m_LeftHandAction.action.canceled += (InputAction.CallbackContext _) => { _sprintPressed = false; };
    }

    private void Update()
    {
        m_continuousMoveProvider.moveSpeed = _sprintPressed ? _sprintSpeed : _initialSpeed;
    }
}
