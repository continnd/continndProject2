using UnityEngine;
using System.Collections;


public class BulletCollision : MonoBehaviour {

    public GameObject explosionPrefab;

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == "enemy") {
            Destroy(collision.gameObject, 0.0f);
            Destroy(gameObject, 0.0f);
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            GameObject explosion = Instantiate(explosionPrefab, pos, rot) as GameObject;
            Destroy(explosion, 3.0f);
        }
    }
}
