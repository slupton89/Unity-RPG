using UnityEngine;

public class ConsumableController : MonoBehaviour {

    CharacterStats stats;

    void Start() {
        stats = GetComponent<PlayerScript>().characterStats;
    }

    public void ConsumeItem(Item item) {
        GameObject ItemtoSpawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.ObjectSlug));
        if (item.ItemModifier) {
            ItemtoSpawn.GetComponent<IConsumable>().Consume(stats);
        } else {
            ItemtoSpawn.GetComponent<IConsumable>().Consume();
        }
    }
}
