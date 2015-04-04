using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CannonLaunch : MonoBehaviour {

    public GameObject cbPrefab;
    public GameObject graphics;
    public float cannonSpeed = 100.0f;
    public int magazine = 10;
    public GameObject[] bullets;
    public Text text;
    private float dispWarning = 0;
    private int sign = 1;
    private float alpha = 0f;

    void Start() {
        text.enabled = false;
    }

    void Update () {
        if (magazine != 0)
            StopCoroutine("TextFade");
        if (Input.GetButtonDown("Fire1") && magazine > 0) {
            GameObject cbInstance;
            cbInstance = Instantiate(cbPrefab, gameObject.transform.position,
                    gameObject.transform.rotation * Quaternion.Euler(0, 0, 90)) as GameObject;
            cbInstance.rigidbody.velocity = transform.TransformDirection(Vector3.forward * cannonSpeed);
            Physics.IgnoreCollision(graphics.collider, cbInstance.collider);
            Destroy(cbInstance, 10.0f);
            magazine--;
            bullets[magazine].SetActive(false);
            if (magazine == 0) {
                dispWarning = 0;
                alpha = 0;
                text.enabled = true;
                StartCoroutine("TextFade");
            }
        }
    }

    IEnumerator TextFade() {
        while (true) {
            dispWarning += Time.deltaTime;
            if (dispWarning > 1.5f) {
                // text.enabled = !text.enabled;
                dispWarning = 0;
                sign = -1 * sign;
            }
            alpha += sign * .01f;
            text.color = new Color(1, 1, 1, alpha);
            yield return new WaitForSeconds(0);
        }
    }
}
