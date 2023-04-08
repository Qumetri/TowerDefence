using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] Transform[] points;
    [SerializeField] GameObject impactPrefab;
    //[SerializeField] GameObject impact;
    [SerializeField] int damage = 5; 
    [SerializeField]public float speed = 15;
    [SerializeField] public int enemyhp = 10;
    Transform targetPoint;
    Master master;

    int i = 0;
    void Start()
    {
        targetPoint = WayPoints.points[0];
        master = GameObject.Find("MASTER").GetComponent<Master>();
    }

    // Update is called once per frame
    void GetNextPoint()
    {
        i++;
        if (i >= WayPoints.points.Length)
        {
            EnemyOnBase();
        }
        else targetPoint = WayPoints.points[i];
    }
    void EnemyOnBase()
    {
        GameObject.Find("Base").GetComponent<BaseScript>().baseHp -= damage;
        Destroy(gameObject);
    }
    void Update()
    {
        Vector3 dir = targetPoint.position - transform.position; //Finding right direction.
        transform.Translate(dir.normalized * speed * Time.deltaTime);
        if(dir.magnitude < 0.8f)
        {
            GetNextPoint();
        }
        if (enemyhp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            EnemyDead();
        }
    }

    private void EnemyDead()
    {
       

            GameObject impact = Instantiate(impactPrefab, transform.position, transform.rotation);
            Destroy(impact, 2);
            Destroy(gameObject);
            master.Money += 5;
        
    }
}
