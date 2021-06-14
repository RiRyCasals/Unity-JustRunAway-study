using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitController : MonoBehaviour 
{
    public GameObject player;
    public GameObject text;

    private RestartManager restartManager;

    private void Start() {
        restartManager = new RestartManager(player, text);
    }

    private void Update() {
        if (restartManager.IsGameOver() && Input.GetMouseButton(0)) {
            restartManager.Restart();
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == player.name) {
            restartManager.PrintGameOver();
        }
    }
}
