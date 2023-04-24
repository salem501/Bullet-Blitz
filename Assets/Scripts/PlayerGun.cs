using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField]
    public Transform firingPoint;
    [SerializeField]
    public float fireSpeed;

    private float lastTimeShot = 0;

    public static PlayerGun Instance;
    void Awake()
    {
        Instance = GetComponent<PlayerGun>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot() {
        if (Time.time > lastTimeShot + fireSpeed) {
            Projectile projectile = ProjectilePool.Instance.Instantiate(firingPoint.position, firingPoint.rotation);
            projectile.activateProjectile();
            lastTimeShot = Time.time;
        }
    }
}
