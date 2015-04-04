using UnityEngine;
using System.Collections;

public class WaterBulletCollisions : MonoBehaviour {
    public GameObject ammo;
    private MyMouseLook script;
    private CharacterController controller;
    private Transform player;

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == "enemy") {
            GameObject.Find("GameManager").GetComponent<statUpdater>().updateEnemies();
            if (Random.Range(0.0f, 3.0f) <= 1.0f) {
                GameObject.Instantiate(ammo, collision.transform.position,
                        Quaternion.identity);
            }
            Destroy(collision.gameObject);
        } else if (collision.gameObject.tag == "Player") {
            GameObject.Find("GameManager").GetComponent<statUpdater>().updateLives();
            GameObject.Find("GameManager").GetComponent<statUpdater>().Death();
        }
        Destroy(gameObject);
    }
}
