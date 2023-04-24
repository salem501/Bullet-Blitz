using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingSpeedButton : MonoBehaviour
{
    private PlayerGun playerGun;
    private Button button;
    private PlayerController player;

    void Start() {
        player = FindAnyObjectByType<PlayerController>();
        playerGun = FindAnyObjectByType<PlayerGun>();
        button = GetComponent<Button>();
    }

    private void Update() {
        button.interactable = player.levelUp > 0;
    }

    public void OnButtonPress() {
        playerGun.fireSpeed -= 0.1f;
        player.levelUp--;
        player.lastLevelUpgrade = player.level - player.levelUp;
    }
}
