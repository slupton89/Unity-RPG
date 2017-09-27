﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {
    [HideInInspector]
    public NavMeshAgent playerAgent;
    private bool hasInteracted;
    bool isEnemy;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent) {
        isEnemy = gameObject.tag == "Enemy"; 
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        playerAgent.destination = transform.position;

    }

    void Update() {
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending) {

            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance) {

                if (!isEnemy) {                    
                    Interact();                    
                }
                hasInteracted = true;
                EnsureLookDirection();

            }
        }
    }

    void EnsureLookDirection() {
        //playerAgent.updateRotation = false;
        Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        playerAgent.transform.LookAt(lookDirection);
        //playerAgent.updateRotation = true;
    }

    public virtual void Interact() {

        Debug.Log("Interacting with base class");
    }

}
