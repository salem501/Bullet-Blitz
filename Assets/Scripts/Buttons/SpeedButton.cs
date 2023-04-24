using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedButton : MonoBehaviour
{
    private PlayerController player;
    private float lastTimePressed;
    private bool playerOnFire = false;
    private Button button;

    void Start() {
        player = FindAnyObjectByType<PlayerController>();
        button = GetComponent<Button>();

    }

    private void Update() {
        button.interactable = player.levelUp > 0;
        if (Time.time - lastTimePressed > 5 && playerOnFire) {
            player.movSpeed -= 2;
            playerOnFire = false;
        }
    }

    public void OnButtonPress() {
        player.movSpeed += 2;
        lastTimePressed = Time.time;
        playerOnFire = true;
        player.levelUp--;
        player.lastLevelUpgrade = player.level - player.levelUp;
    }
}
