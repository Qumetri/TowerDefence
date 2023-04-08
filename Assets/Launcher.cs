using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform target;
    [SerializeField] float turretRange = 18;
    [SerializeField] float fireRate = 2;
    void Start()
    {
        InvokeRepeating("SeekTarget", 0, 1 / fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            //Pointing on target
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
            StartCoroutine(Shoot());
        }



    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.2f);//tower rotation time
        GameObject missileGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        missileGO.GetComponent<Missile>().mTarget = target;
    }
}
