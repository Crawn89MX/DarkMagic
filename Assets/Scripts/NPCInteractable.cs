using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : Interactable
{

    [SerializeField]
    private string _name;
    [SerializeField]
    private string[] _dialogue;

    public override void Interact()
    {
        // base.Interact();
        Debug.Log("Interactuando con un NPC");
        //Usar un manejador de diálogos para mostrar los diálogos
    }

}
