using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField]
    public Transform firingPoint;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float fireSpeed;

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
            Instantiate(projectile, firingPoint.position, firingPoint.rotation);
            lastTimeShot = Time.time;
        }
    }
}
