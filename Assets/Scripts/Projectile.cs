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
    [SerializeField] GameObject explosionPrefab;

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
        //explosionPrefab = Resources.Load("Assets/msVFX_Free Smoke Effects Pack/Prefabs/msVFX_Stylized Smoke 3.prefab") as GameObject;
        triggeringEnemy = other.gameObject;
        triggeringEnemy.GetComponent<EnemyController>().health -= damage;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
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
