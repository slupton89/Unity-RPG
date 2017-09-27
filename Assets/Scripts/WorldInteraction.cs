using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

    NavMeshAgent playerAgent;

    void Start() {

        playerAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {

        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
            GetInteraction();
        }
    }

    void GetInteraction() {

        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity)) {
            GameObject interactedObject = interactionInfo.collider.gameObject;

            if (interactedObject.tag == "Enemy") {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            } else if (interactedObject.tag == "InteractableObject") {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            } else {
                playerAgent.stoppingDistance = 0f;
                playerAgent.destination = interactionInfo.point;
            }
        }
    }
}
