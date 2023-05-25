using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class NoteManager : MonoBehaviour
{
    public static int TotalNotes = 6;

    [SerializeField]
    TMP_Text notesText;
    [SerializeField]
    NavMeshAgent shrek;

    [SerializeField]
    GameObject wall;


    private void OnLevelWasLoaded(int level)
    {
        TotalNotes = 0;
    }
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
            case 7:
                OpenExit();
                notesText.text = "Run to the exit!";
                break;
            default:
                break;
        }
    }

    public void ChangeText()
    {
        notesText.text = TotalNotes.ToString();
    }
    public void OpenExit()
    {
        wall.transform.position += new Vector3(7f, 0f, 0f);
    }
}
