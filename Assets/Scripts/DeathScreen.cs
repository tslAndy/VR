using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField]
    private Transform cam;

    private float spawnDistance = 2;

    private void Update()
    {

        transform.position = cam.position + new Vector3(cam.forward.x, 0, cam.forward.z).normalized * spawnDistance;
        transform.LookAt(new Vector3(cam.position.x, transform.position.y, cam.position.z));
        transform.forward *= -1;
    }
}
