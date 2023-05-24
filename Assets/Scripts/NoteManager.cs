using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class NoteManager : MonoBehaviour
{
    public static int TotalNotes = 0;

    [SerializeField]
    TMP_Text notesText;
    [SerializeField]
    NavMeshAgent shrek;

    public void AddNote(GameObject note)
    {
        TotalNotes++;
        ChangeText();
        note.SetActive(false);
        switch (TotalNotes)
        {
            case 3:
                shrek.speed *= 1.5f;
                shrek.GetComponent<Animator>().SetTrigger("MoveToNextPhase");
                break;
            case 6:
                shrek.speed *= 1.5f;
                shrek.GetComponent<Animator>().SetTrigger("MoveToLastPhase");
                break;
            default:
                break;
        }
    }

    public void ChangeText()
    {
        notesText.text = TotalNotes.ToString();
    }
}
