using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnShrekCollision : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shrek"))
        {
            deathScreen.SetActive(true);
        }
    }
}
