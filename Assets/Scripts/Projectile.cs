using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 firingPoint;
    
    [SerializeField]
    private float projectileSpeed;
    [SerializeField]
    private float maxFireRange;
    [SerializeField]
    private float damage;

    private bool shouldMove;
    private GameObject triggeringEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMove) {
            MoveProjectile();
        }
    }

    public void OnTriggerEnter(Collider other) {
        triggeringEnemy = other.gameObject;
        triggeringEnemy.GetComponent<EnemyController>().health -= damage;
        ProjectilePool.Instance.ReturnToPool(this);
        shouldMove = false;
    }

    public void activateProjectile() {
        firingPoint = transform.position;
        shouldMove = true;
    }

    void MoveProjectile() {
        if (Vector3.Distance(firingPoint, transform.position) > maxFireRange) {
            ProjectilePool.Instance.ReturnToPool(this);
            shouldMove = false;
        }
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }
}
