using System;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon {

    public List<BaseStat> Stats { get; set; }
    public CharacterStats CharacterStats { get; set; }
    public int CurrentDamage { get; set; }
    public Transform ProjectileSpawn { get; set; }
    Fireball fireball;
    Animator anim; 

    void Start() {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
        anim = GetComponent<Animator>();
    }

    public void PerformAttack(int damage) {
        anim.SetTrigger("Base Attack");
    }

    public void CastProjectile() {
        Fireball fireballInstance = Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
        fireballInstance.Direction = ProjectileSpawn.forward;
    }
}
