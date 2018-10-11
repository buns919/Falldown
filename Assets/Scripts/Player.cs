using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float moveSpeed = 100f;

    private Rigidbody rb;
	
	// Update is called once per frame
	void Update () {

    }


    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        MoveHorizontal();
    }

    private void MoveHorizontal() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        rb.AddForce(movement * moveSpeed);
    }

}
