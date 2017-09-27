using System;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable {

    public void Consume() {
        Debug.Log("You drank a swig of the potion");
        Destroy(gameObject);
    }

    public void Consume(CharacterStats stats) {
        Debug.Log("You drank a swig of the potion, cool");
    }

}
