using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public float range = 15f;
    public float turnSpeed = 10f;
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);//chamando com pausa
        
    }

    // Update is called once per frame
    void Update()
    {
       if(target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemey = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemey = enemy;
            }
        }
        if(nearestEnemey != null && shortestDistance <= range)
        {
            target = nearestEnemey.transform;
        }
        else
        {
            target = null;
        }
    }

 
    void OnDrawGizmosSelected()
    {
       
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
