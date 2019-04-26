using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public string[] dialogLines;
    public string[] consequenceLines;
    public int currentLine;
    public int currentConsequence;
    public TextMeshProUGUI dialogText;

    public GameObject dialogBox;
    public GameObject[] buttons;
    NPC_Interaction _Interaction;
    public bool isDialogActive;
    private bool isConsequencesPlaying;

    private void Awake()
    {
        _Interaction = FindObjectOfType<NPC_Interaction>();
        dialogBox.SetActive(false);
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogActive && Input.GetKeyDown(KeyCode.Tab))
        {
            currentLine++;
        }

        if (currentLine >= dialogLines.Length || currentLine >= consequenceLines.Length)
        {
            if (_Interaction.isQuestNPC)
            {
                buttons[0].SetActive(true);
                buttons[1].SetActive(true);
            }
            if (_Interaction.isConsequentialNPC)
            {
                buttons[1].SetActive(true);
                buttons[2].SetActive(true);
            }
            isDialogActive = false;
        }

        if (currentLine < dialogLines.Length)
        {
            buttons[0].SetActive(false);
            buttons[1].SetActive(false);
            buttons[2].SetActive(false);
        }
        if (isConsequencesPlaying)
        {
            currentLine = 0;
            dialogText.text = consequenceLines[currentLine];
        }
        else
        {
            dialogText.text = dialogLines[currentLine];
        }
    }

    public void ShowDialog()
    {
        dialogBox.SetActive(true);
        isDialogActive = true;
    }

    public void ShutOffDialog()
    {
        dialogBox.SetActive(false);
        isDialogActive = false;
        currentLine = 0;
    }

    public void ConsequenceDialog1()
    {
        isConsequencesPlaying = true;
    }
}
