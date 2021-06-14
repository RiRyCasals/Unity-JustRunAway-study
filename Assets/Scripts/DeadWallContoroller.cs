using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;

public class DeadWallContoroller : MonoBehaviour
{
    public float speed = 0.01f;
    public float max_x = 10.0f;

    public GameObject player;
    public GameObject text;

    private bool isGameOver = false;

    private RestartManager restartManager;

    private void Start() {
        restartManager = new RestartManager(player, text);
    }

    private void Update() {
        this.gameObject.transform.Translate(speed, 0, 0);
        if (this.gameObject.transform.position.x > max_x || this.gameObject.transform.position.x < (-max_x)) {
            speed *= -1;
        }
        if (restartManager.IsGameOver() && Input.GetMouseButton(0)) {
            restartManager.Restart();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == player.name) {
            restartManager.PrintGameOver();
        }
    }
}
