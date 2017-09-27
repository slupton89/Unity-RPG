using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : Interactable, IEnemy {

    public LayerMask aggroLayerMask;
    public float currentHealth, power, toughness;
    public float maxHealth;
    public int Experience { get; set; }
    public DropTable DropTable { get; set; }
    public PickupItem pickupItem;

    private PlayerScript player;
    private NavMeshAgent navAgent;
    private CharacterStats characterStats;
    private Collider[] withinAggroColliders;

    void Start() {
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop> {
            new LootDrop("sword", 25),
            new LootDrop("staff", 25),
            new LootDrop("potion_log", 25)
        };

        Experience = 20;
        navAgent = GetComponent<NavMeshAgent>();
        characterStats = new CharacterStats(6, 10, 2);
        currentHealth = maxHealth;
    }

    void FixedUpdate() {
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10, aggroLayerMask);
        if (withinAggroColliders.Length > 0) {
            ChasePlayer(withinAggroColliders[0].GetComponent<PlayerScript>());
        }
    }


    public void TakeDamage(int amount) {
        currentHealth -= amount;
        if ( currentHealth <= 0) {
            Die();
        }
    }

    void ChasePlayer(PlayerScript player) {
        navAgent.SetDestination(player.transform.position);
        this.player = player;
        if(navAgent.remainingDistance <= navAgent.stoppingDistance) {
            Debug.Log("remaining: " + navAgent.remainingDistance);
            if (!IsInvoking("Attack")) {
                
                InvokeRepeating("Attack", .1f, 2f);
            } else {
                Debug.Log("out of range");
                CancelInvoke("Attack");
            }
            
        }
        
    }

    public void Attack() {
        player.TakeDamage(5);
    }

    public void Die() {
        DropLoot();
        CombatEvent.EnemyDied(this);
        Destroy(gameObject);
    }

    void DropLoot() {
        Item item = DropTable.GetDrop();
        if(item != null) {
            PickupItem instance = Instantiate(pickupItem, transform.position, Quaternion.identity);
            instance.ItemDrop = item;
        }
    }
}
