using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class statUpdater : MonoBehaviour {

    private int enemiesLeft;
    private int lives = 3;
    public Text numEnemies;
    public Text text;
    public Image[] livesIcons;
    public GameObject player;
    public CharacterController controller;
    public Camera FPCam;
    public Camera deathCamera;
    
    void Start() {
        enemiesLeft = gameObject.GetComponent<Spawner>().totalToSpawn;
        numEnemies.text = "" + enemiesLeft;
    }
	
    public void updateEnemies() {
        enemiesLeft--;
        numEnemies.text = "" + enemiesLeft;
    }

    public void updateLives() {
        lives--;
        Destroy(livesIcons[lives]);
    }

    public void Death() {
        MyMouseLook script = player.GetComponent<MyMouseLook>();
        FPCam.GetComponent<MyMouseLook>().enabled = false;
        FPCam.GetComponent<CannonLaunch>().enabled = false;
        FPCam.enabled = false;
        script.enabled = false;
        player.transform.Rotate(Vector3.right * 180);
        player.GetComponent<WASDMovementWithController>().enabled = false;
        player.tag = null;
        controller.enabled = false;
        Invoke("Respawn", 5.0f);
    }

    void Respawn() {
        player.GetComponent<WASDMovementWithController>().enabled = true;
        FPCam.enabled = true;
        FPCam.GetComponent<CannonLaunch>().enabled = true;
        FPCam.GetComponent<MyMouseLook>().enabled = true;
        MyMouseLook script = player.GetComponent<MyMouseLook>();
        script.enabled = true;
        player.transform.Rotate(Vector3.right * 180);
        controller.enabled = true;
        player.tag = "Player";
        Reload();
    }

    public void Reload() {
        CannonLaunch shootScript = FPCam.GetComponent<CannonLaunch>();
        shootScript.magazine = 10;
        for (int i = 0; i < shootScript.bullets.Length; i++) {
            shootScript.bullets[i].SetActive(true);
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);
        text.enabled = false;
    }
}
