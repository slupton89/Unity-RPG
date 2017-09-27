using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 distance;
	void Start () {
	
	}
	

	void FixedUpdate () {

        gameObject.transform.position = target.transform.position + distance;
        
	}
}
