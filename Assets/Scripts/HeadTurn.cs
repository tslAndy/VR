using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTurn : MonoBehaviour
{
    [SerializeField]
    private Transform _neckBone; // The transform that will be rotated (neck in this case)
    [SerializeField]
    private float _searchRadius = 10f;

    [Header("Minimum and maximum rotation values")]
    [SerializeField]
    private float xMax = 30f;
    [SerializeField]
    private float yMax = 80f;
    [SerializeField]
    private float xMin = -15f;
    [SerializeField]
    private float yMin = -80f;

    private void FixedUpdate()
    {
        GameObject player = FindPlayerInRadius(_searchRadius);
        if (player != null)
        {
            //_neckBone.LookAt(player.transform); // Might need Quaternion.Slerp
            //_neckBone.rotation = Quaternion.RotateTowards(_neckBone.transform.rotation, player.transform.rotation, Time.deltaTime * 100);
            Quaternion looking = Quaternion.LookRotation(player.transform.position - _neckBone.position);
            Debug.Log(looking.eulerAngles);
            looking.eulerAngles = ClampAngles(looking);
            Debug.Log(looking.eulerAngles);
            _neckBone.rotation = Quaternion.Slerp(_neckBone.rotation, looking, Time.deltaTime * 3);
        }
    }

    // Returns a "Player"-tagged GameObject within a sphere or returns null if there's no such GameObject in it
    public GameObject FindPlayerInRadius(float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in hitColliders) 
        {
            if (collider.CompareTag("Player"))
            {
                return collider.gameObject;
            }
        }
        return null;
    }

    // Set X and Y of rotation to be within certain bounds
    public Vector3 ClampAngles(Quaternion rotation)
    {
        Vector3 angles = rotation.eulerAngles;
        float newX = Mathf.Clamp(angles.x, xMin, xMax);
        float newY = Mathf.Clamp(angles.y, yMin, yMax);
        // Clamp X
        //if (angles.x > xMax)
        //{
        //    newX = xMax;
        //}
        //else if (angles.x < xMin)
        //{
        //    newX = xMin;
        //}
        //else
        //{
        //    newX = angles.x;
        //}

        //// Clamp Y
        //if (angles.y > yMax)
        //{
        //    newY = yMax;
        //}
        //else if (angles.y < yMin)
        //{
        //    newY = yMin;
        //}
        //else
        //{
        //    newY = angles.y;
        //}

        angles = new Vector3(newX, newY, angles.z);

        return angles;
    }
}
