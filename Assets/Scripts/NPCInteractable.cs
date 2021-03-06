using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : Interactable
{

    [SerializeField]
    private string _name;
    [SerializeField]
    private string[] _dialogue;

    private DialogueManager _dialogueManager; // *******************

    private void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>(); //Sirve para singletons
        if (_dialogueManager == null)
        {
            Debug.LogWarning("No se encontr? un DialogueManager en la escena");
        }
    }


    public override void Interact()
    {
        // base.Interact();
        Debug.Log("Interactuando con un NPC");
        _dialogueManager.SetDialogue(_name, _dialogue);
        //Usar un manejador de di?logos para mostrar los di?logos
    }

}
