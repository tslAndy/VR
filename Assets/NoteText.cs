using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NoteText : MonoBehaviour
{
    [SerializeField] private GameObject noteCanvas;

    public void ShowText()
    {
        noteCanvas.SetActive(true);
    }
    public void HideText()
    {
        Destroy(noteCanvas);
    }

}
