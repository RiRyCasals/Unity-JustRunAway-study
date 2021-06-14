using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public GameObject player;
    public GameObject text;
    private RestartManager restartManager;

    private void Start() {
        restartManager = new RestartManager(player, text);
    }

    private void Update() {
        if (player.transform.position.y < -10) {
            restartManager.PrintGameOver();
        }
        if (restartManager.IsGameOver() && Input.GetMouseButton(0)) {
            restartManager.Restart();
        }
    }
}
