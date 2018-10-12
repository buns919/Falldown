using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float moveSpeed = 100f;

    private Rigidbody rb;
    private bool isFalling = false;
	
	// Update is called once per frame
	void Update () {

    }


    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        MoveHorizontal();

        /*
        // if we are not falling and on a platform, apply the horizontal force
        if (!isFalling) {
            MoveHorizontal();
        }
        // try to limit the horizontal momentum when falling so we fall more straight down
        else if (rb.velocity.x > 1.5f) {
            rb.velocity = new Vector3(rb.velocity.x * .8f, rb.velocity.y, 0f);
        }
        */
    }

    private void MoveHorizontal() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        rb.AddForce(movement * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Platform") {
            isFalling = false;
        }

    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Platform") {
            isFalling = true;
        }
    }

}
