using UnityEngine;

public class PickupItem : Interactable {

    public Item ItemDrop { get; set; }

    public override void Interact() {
        Debug.Log("Interacting");
        InventoryController.Instance.GiveItem(ItemDrop);
        Debug.Log("Picked up " + ItemDrop);
        Destroy(gameObject);
    }

}
