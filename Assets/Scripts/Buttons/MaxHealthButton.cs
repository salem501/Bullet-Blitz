using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxHealthButton : MonoBehaviour
{
    private PlayerController player;
    private Button button;
    void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
        button = GetComponent<Button>();
    }

    private void Update() {
        button.interactable = player.levelUp > 0;
    }

    public void OnButtonPress() {
        player.maxHealth += 10;
        player.levelUp--;
        player.lastLevelUpgrade = player.level - player.levelUp;
    }
}
