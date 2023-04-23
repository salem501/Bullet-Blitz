using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthButton : MonoBehaviour
{
    private PlayerController player;
    void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
    }

    public void OnButtonPress() {
        player.maxHealth += 10;
    }
}
