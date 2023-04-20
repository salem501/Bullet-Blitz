using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField]
    private float poolSize;
    [SerializeField]
    GameObject projectilePrefab;

    private List<Projectile> pool;

    public static ProjectilePool Instance;

    void Awake() {
        Instance = GetComponent<ProjectilePool>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializePool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Projectile Instantiate(Vector3 position, Quaternion rotation) {
        Projectile projectile = pool[0];
        projectile.transform.position = position;
        projectile.transform.rotation = rotation;
        pool.Remove(projectile);
        
        return projectile;
    }

    public void ReturnToPool( Projectile projectile) {
        projectile.transform.position = transform.position;
        pool.Add(projectile);
    }

    void InitializePool() {
        pool = new List<Projectile>();
        for (int i = 0; i < poolSize; i++) {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            pool.Add(projectile.GetComponent<Projectile>());
        }
    }

}
