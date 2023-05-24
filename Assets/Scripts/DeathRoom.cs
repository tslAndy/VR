using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathRoom : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;


    public void Restart()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void Quit() => Application.Quit();

}
