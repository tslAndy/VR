using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ripples : MonoBehaviour
{
    [SerializeField] private ParticleSystem ripple;
    [SerializeField] InputActionProperty m_LeftHandMoveAction;
    [SerializeField] GameObject rippleCamera;
    private void Update()
    {
        rippleCamera.transform.position = transform.position + Vector3.up * 10;
        
    }

    public void CreateRipple(int start, int end, int delta, float Speed, float Size, float LifeTime)
    {
        Vector3 forward = ripple.transform.eulerAngles;
        forward.y = start;
        ripple.transform.eulerAngles = forward;
        for(int i = start; i < end; i+= delta)
        {
            ripple.Emit(transform.position + ripple.transform.forward * 0.5f, ripple.transform.forward * Speed, Size, LifeTime, Color.white);
            ripple.transform.eulerAngles += Vector3.up * 3;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 4 && m_LeftHandMoveAction.action.ReadValue<Vector2>() != Vector2.zero)
        {
            CreateRipple(-180, 180, 3, 2, 1, 2);
            Debug.Log("Create ripple enter");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 4 && m_LeftHandMoveAction.action.ReadValue<Vector2>() != Vector2.zero && Time.renderedFrameCount % 5 == 0)
        {
            int y = (int)transform.eulerAngles.y;
            CreateRipple(y-100, y+100, 3, 5, 0.5f, 1);
            //Debug.Log("Create ripple exit");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.layer == 4 && m_LeftHandMoveAction.action.ReadValue<Vector2>() != Vector2.zero)
        {
            CreateRipple(-180, 180, 3, 2, 1, 2);
            Debug.Log("Create ripple exit");
        }
    }
}
