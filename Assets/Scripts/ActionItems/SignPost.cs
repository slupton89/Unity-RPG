using UnityEngine;

public class SignPost : ActionItem {
    public string[] dialogue;

    public override void Interact() {

        DialogueSystem.instance.AddNewDialog(dialogue, "Sign");

        Debug.Log("Interacting with sign post");
    }

}
