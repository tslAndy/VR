using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTurn : MonoBehaviour
{
    [SerializeField]
    private Transform _neckBone; // The transform that will be rotated (neck in this case)
    [SerializeField]
    private float _searchRadius = 10f;

    private void FixedUpdate()
    {
        GameObject player = FindPlayerInRadius(_searchRadius);
        if (player != null)
        {
            _neckBone.LookAt(player.transform); // Might need Quaternion.Slerp
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
}
