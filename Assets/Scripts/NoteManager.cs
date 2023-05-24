using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteManager : MonoBehaviour
{
    public static int TotalNotes = 0;

    [SerializeField]
    TMP_Text notesText;

    public void AddNote(GameObject note)
    {
        TotalNotes++;
        ChangeText();
        note.active = false;
        Debug.Log(TotalNotes);
    }

    public void ChangeText()
    {
        notesText.text = TotalNotes.ToString();
    }
}
