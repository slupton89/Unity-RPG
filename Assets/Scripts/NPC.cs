using UnityEngine;
using System.Collections.Generic;

public class NPC : Interactable {

    public string[] dialogue;
    public string npcName;

    public override void Interact() {

        DialogueSystem.instance.AddNewDialog(dialogue, npcName);
        Debug.Log("Interacting with NPC");
    }


}
