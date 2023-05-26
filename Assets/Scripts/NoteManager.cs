using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{
    public static int TotalNotes = 0;

    [SerializeField]
    TMP_Text notesText;
    [SerializeField]
    NavMeshAgent shrek;
    [SerializeField] private GameObject[] notesCanvas;

    public void AddNote(GameObject note)
    {
        TotalNotes++;
        ChangeText();
        note.SetActive(false);
        if (notesCanvas[TotalNotes - 1].gameObject != null)
        {
            notesCanvas[TotalNotes - 1].SetActive(true);
        }
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
