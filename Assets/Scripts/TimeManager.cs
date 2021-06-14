using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;

public class TimeManager : MonoBehaviour
{
    private RestartManager restartManager;

    public Text timeText;
    public float limit = 30.0f;
    public GameObject text;
    public GameObject player;
    private bool isGameOver = true;

    private void Start() {
        timeText.text = "remaining time : " + limit + " seconds";
        restartManager = new RestartManager(player, text);
    }

    private void Update() {
        if (restartManager.IsGameOver() && Input.GetMouseButton(0)) {
            restartManager.Restart();
        }
        if (limit < 0) {
            restartManager.PrintGameOver();
            return;
        }
        limit -= Time.deltaTime;
        timeText.text = "remaining time : " + limit.ToString("f1") + " seconds";
    }
}
