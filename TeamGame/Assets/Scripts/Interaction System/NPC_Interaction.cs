using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interaction : MonoBehaviour, IInteractable
{
    // Interaction Variables
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 10;
    public Transform player;
    float distance;
    [HideInInspector] public bool canInteract;

    //Dialog Variables
    DialogManager dialogManager;
    public bool isQuestNPC;
    public bool isConsequentialNPC;
    public bool isShopNPC;


    // Start is called before the first frame update
    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Every Frame will update the distance between the player and the interactable
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        // If the distance between the player and the interactable is Less Than or Equal to the max range
        if (distance <= maxRange)
        {
            //Do the In Range
            InRange();
            //Set can interact bool to true
            canInteract = true;
        }
        else
        {
            // Do the Not In Range 
            NotInRange();
            // Set can interact bool to false
            canInteract = false;
        }
        // If the player presses the key and if he can interact 
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            // Do the Interact
            Interact();
        }
    }

    public void InRange()
    {
        Debug.Log("In Range");
    }

    public void Interact()
    {
        dialogManager.ShowDialog();
    }

    public void NotInRange()
    {
        Debug.Log("Not In Range");
    }
}
