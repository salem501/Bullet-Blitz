using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    public float health;
    [SerializeField]
    private float pointsValue;
    [SerializeField]
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        print(this.gameObject.name + "was killed!");
        Destroy(this.gameObject);
        player.points += pointsValue;
    }
}
