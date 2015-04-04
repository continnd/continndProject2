using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Reload : MonoBehaviour {
    void Update() {
        gameObject.transform.Rotate(Vector3.up * 3);
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            GameObject.Find("GameManager").GetComponent<statUpdater>().Reload();
            Destroy(gameObject);
        }
    }
}
