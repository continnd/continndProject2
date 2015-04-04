using UnityEngine;
using System.Collections;

public class CounterFire : MonoBehaviour {
    public GameObject cbPrefab;
    public GameObject graphics;
    public float cannonSpeed = 100.0f;
    private float fireCounter = 0;

	void Update () {
        fireCounter += Time.deltaTime;
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        GameObject target = GameObject.FindGameObjectWithTag("Player") as GameObject;
        if (target != null) {
            if ((target.transform.position - transform.position).magnitude < 20 && fireCounter > 1.0f) {
                Fire(target);
                fireCounter = 0;
            }
            for (int i = 0; i < projectiles.Length; i++) {
                if ((projectiles[i].transform.position - transform.position).magnitude < 8 && fireCounter > 1.0f) {
                    Fire(target);
                    fireCounter = 0;
                    break;
                }
            }
        }
    }

    void Fire(GameObject target) {
        Vector3 temp = (target.transform.position - transform.position);
        temp.Normalize();
        gameObject.transform.forward = temp;
        gameObject.GetComponent<ControllerMover>().directionVector = temp;
        GameObject cbInstance = Instantiate(cbPrefab,
                gameObject.transform.position,
                gameObject.transform.rotation *
                Quaternion.Euler(0, 0, 90)) as GameObject;
        cbInstance.rigidbody.velocity =
            transform.TransformDirection(Vector3.forward * cannonSpeed);
        Physics.IgnoreCollision(graphics.collider, cbInstance.collider);
        Destroy(cbInstance, 10.0f);
    }
}
