using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]

public class ControllerMover : MonoBehaviour {

    CharacterController controller;
    public float ForwardSpeed=5.0f;
    public float maxRotationSpeed=5.0f;
    public Vector3 directionVector;
    private float fallSpeed;
    private Vector3 gravity;
    public bool gravityOn = true;

	// Use this for initialization
	void Start () {
	    controller = GetComponent<CharacterController>();
        directionVector = transform.forward + new Vector3(0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (gravityOn)
            if (!controller.isGrounded) {
                fallSpeed += Physics.gravity.y * Time.deltaTime;
            } else {
                gravityOn = false;
                fallSpeed = 0;
            }
        gravity = new Vector3(0.0f, fallSpeed, 0.0f);

        transform.forward = Vector3.Slerp(transform.forward, directionVector, Time.deltaTime * maxRotationSpeed);
	    controller.Move(directionVector * ForwardSpeed * Time.deltaTime
                + gravity);
	}

    void OnControllerColliderHit (ControllerColliderHit hit) {
        directionVector = Vector3.Reflect(directionVector, hit.normal);
        directionVector = new Vector3(directionVector.x, 0.0f, directionVector.z);
        directionVector.Normalize();
    }
}
