using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private string IS_DEAD = "isDead";
    private Animator animator;
    public float health;
    private bool setHealth = true;
    [SerializeField]
    private int pointsValue;
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
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        move();
        setMaxHealth();
        Die();
    }

    private void setMaxHealth() {
        if (setHealth) {
            health = 100 + 10 * player.level;
            setHealth = false;
        }
        if (player.levelUpBool) {
            setHealth = true;
        }
            
    }
    /*
    private void move() {
        float overlapDistance = 2.0f;
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        Vector3 targetPosition = transform.position + moveDirection * Time.deltaTime * movSpeed;
        Collider[] colliders = Physics.OverlapSphere(targetPosition, overlapDistance);

        // Loop through all colliders and check for overlapping enemies
        foreach (Collider collider in colliders) {
            if (collider.gameObject != gameObject && collider.CompareTag("Enemy")) {
                return;
            }
        }
        transform.LookAt(new Vector3(player.transform.position.x, 3, player.transform.position.z));
        transform.position = targetPosition;
    }
    */
    private void move() {
        this.transform.LookAt(new Vector3(player.transform.position.x, 0, player.transform.position.z));
        transform.position += transform.forward * Time.deltaTime * movSpeed;
    }
    
    public void OnTriggerEnter(Collider other) {
        if (collided == false && other == player.gameObject.GetComponent<Collider>()) {
            player.lastTimeHit = Time.time;
            collided = true;
            Destroy(this.gameObject);
            player.health -= collisionDamage;
        }
    }

    private void Die() {
        if (health <= 0) {
            print(this.gameObject.name + "was killed!");
            movSpeed = 0;
            animator.SetBool(IS_DEAD, true);
        }
    }

    private void destroy() {
        Destroy(this.gameObject);
        player.points += pointsValue;
    }
}
