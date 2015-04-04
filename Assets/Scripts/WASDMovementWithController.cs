using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class WASDMovementWithController : MonoBehaviour {
    public float fSpeed = 3.0f;
    private CharacterController controller;
    private float fallSpeed;
    public float jumpSpeed = 0.5f;
    public bool gravityOn = true;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

	void Update() {
        Vector3 moveVector = Vector3.zero;

        if (gravityOn)
            if (!controller.isGrounded) {
                fallSpeed += Physics.gravity.y * Time.deltaTime;
            } else {
                fallSpeed = 0;
            }

        if (Input.GetButtonDown("Jump")) {
                fallSpeed = jumpSpeed;
        }

        if (Input.GetKey(KeyCode.W)) {
            moveVector = transform.TransformDirection(Vector3.forward) * fSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) {
            moveVector += transform.TransformDirection(Vector3.back) * fSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) {
            moveVector += transform.TransformDirection(Vector3.left) * fSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) {
            moveVector += transform.TransformDirection(Vector3.right) * fSpeed * Time.deltaTime;
        }

        moveVector.y = fallSpeed;
        controller.Move(moveVector);
    }
}
