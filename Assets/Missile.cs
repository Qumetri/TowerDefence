using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform mTarget;
    [SerializeField] float mSpeed = 40;
    [SerializeField] float mRange = 10;
    [SerializeField] Vector3 dir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!mTarget)
        {
            Destroy(gameObject);

            return;
        }



        dir = mTarget.position - transform.position;


        //Vector3 pos = transform.position;
        //pos += dir.normalized * mSpeed * Time.deltaTime;
        //transform.position = pos;
        transform.Translate(dir.normalized * mSpeed * Time.deltaTime, Space.World);
        if (dir.magnitude < 1)
        {
            MImpact();
        }
        transform.LookAt(mTarget);
    }
    void MImpact()
    {
        print("Missile Exploaded");
        Destroy(gameObject);
        ExplosionDamage(transform.position, mRange);
        //explosion effect
    }
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("enemy"))
            {
                //Destroy(hitCollider.gameObject);
                //or do some damage...
                hitCollider.GetComponent<Enemy>().enemyhp -= 1;
            }
        }
    }
}
