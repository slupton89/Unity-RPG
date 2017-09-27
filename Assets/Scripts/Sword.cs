using System;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon {

    private Animator anim;
    public List<BaseStat> Stats { get; set; }
    public CharacterStats CharacterStats { get; set; }
    public int CurrentDamage { get; set; }

    void Start() {
        anim = GetComponent<Animator>();
        Debug.Log(CharacterStats != null);
    }

    public void PerformAttack(int damage) {
        CurrentDamage = damage;
        anim.SetTrigger("Base Attack");
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Enemy") {
            col.GetComponent<IEnemy>().TakeDamage(CurrentDamage);
        }
    }
}
