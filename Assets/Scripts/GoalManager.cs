using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;

public class GoalManager : MonoBehaviour
{
    public GameObject player;
    public GameObject text;
    private bool isGoal = false;

    private RestartManager restartManager;

    void Start() {
        restartManager = new RestartManager(player, text);
    }

    void Update() {
        if (isGoal && Input.GetMouseButton(0)) {
            restartManager.Restart();
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.name == player.name) {
            text.GetComponent<Text>().text = "GOAL!!\n\nClick to restart";
            text.GetComponent<Text>().color = new Color(0, 1, 0);
            text.SetActive(true);
            player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            isGoal = true;
        }
    }
}
