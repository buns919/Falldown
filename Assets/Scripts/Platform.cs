using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    [SerializeField] float verticleMoveSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveVector = Vector3.up * (Time.deltaTime * verticleMoveSpeed);
        transform.Translate(moveVector, Space.World);
    }
}
