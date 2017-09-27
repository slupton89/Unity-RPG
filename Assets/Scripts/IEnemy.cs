using UnityEngine;

public interface IEnemy {

    int Experience { get; set; }
    void Die();
    void TakeDamage(int amount);
    void Attack();
    
}
