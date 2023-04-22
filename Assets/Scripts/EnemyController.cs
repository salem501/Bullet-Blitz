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
    private float collisionDamage;
    [SerializeField]
    private float movSpeed;
    [SerializeField]
    private PlayerController player;

    private bool collided;

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
        
        this.transform.LookAt(new Vector3(player.transform.position.x, 3 ,player.transform.position.z));
        transform.position += transform.forward * Time.deltaTime * movSpeed;
    }

    public void OnTriggerEnter(Collider other) {
        if (collided == false && other == player.gameObject.GetComponent<Collider>()) {
            collided = true;
            Destroy(this.gameObject);
            player.health -= collisionDamage;
        }
    }

    private void Die() {
        print(this.gameObject.name + "was killed!");
        Destroy(this.gameObject);
        player.points += pointsValue;
    }
}
