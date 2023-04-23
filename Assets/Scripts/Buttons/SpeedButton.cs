using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedButton : MonoBehaviour
{
    private PlayerController player;
    private float lastTimePressed;
    private bool playerOnFire = false;
    void Start() {
        player = FindAnyObjectByType<PlayerController>();
    }

    private void Update() {
        if(Time.time - lastTimePressed > 5 && playerOnFire) {
            player.movSpeed -= 2;
            playerOnFire = false;
        }
    }

    public void OnButtonPress() {
        player.movSpeed += 2;
        lastTimePressed = Time.time;
        playerOnFire = true;
    }
}
