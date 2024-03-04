using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("GENERAL")]//muda de uma torre para outra
    public float range = 15f;

    [Header("Use bullets(default)")]
    public float fireRate = 1f;
    private float fireCountDown = 0f;
    public GameObject bulletPrefab;



    [Header("Use Laser")]
    public bool useL = false;

    public int damageOverT  = 30;
    public LineRenderer lineRenderer;
    public float slowP = 0.5f;


    [Header("Unity steup fields")]
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;
    public Transform partToRotate;

    
    public Transform firePoint;
    public AudioSource shootSound;
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
            if(useL)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }

            return;//se nao tiver target nao faz nada
        }

        LockOnTarget();

        if(useL)
        {
            LaserShoot();
        }else
        {
            if (fireCountDown <= 0f)
            {
                shootSound.Play(0);
                Shoot();
                fireCountDown = 1 / fireRate;
            }

            fireCountDown -= Time.deltaTime;

        }

    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemey = null;
        foreach(GameObject enemy in enemies)
        {
            if(enemy.GetComponent<Enemy>().canMoove == true)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemey = enemy;
                }
            }
    
        }
        if(nearestEnemey != null && shortestDistance <= range)
        {
            target = nearestEnemey.transform;
            targetEnemy = nearestEnemey.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

 

    void LaserShoot()
    {

        targetEnemy.TakeDamage(damageOverT * Time.deltaTime);
        targetEnemy.Slow(slowP);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }
    void LockOnTarget()
    {

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Shoot()
    {
      //  Debug.Log("Shoot");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0.0f,0.0f,90.0f));
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
       
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public float getRange()
    {
        return range;
    }
}
