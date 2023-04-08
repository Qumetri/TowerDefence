using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform target;
    [SerializeField] float turretRange = 18;
    [SerializeField]  float fireRate = 2;
    void Start()
    {
        InvokeRepeating("SeekTarget", 0, 1 / fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.LookAt(target);
        }
    }

    void SeekTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float minDist = 100;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(enemy.transform.position, transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy && minDist < turretRange)
        {

            target = nearestEnemy.transform;
            Shoot();
        }


      
    }
    void Shoot()
    {

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
