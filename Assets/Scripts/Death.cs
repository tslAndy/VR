using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private string deathRoomName;
    [SerializeField] private AudioSource _screamerSource;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            _screamerSource.Play();
            StartCoroutine(delayedLoadDeathScene(1.0f));
        }
    }

    // Load the death scene after a delay
    private IEnumerator delayedLoadDeathScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(deathRoomName);
    }
}
