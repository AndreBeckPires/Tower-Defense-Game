using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
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

    [Header("Spawna Algo")]
    public bool spawn_something = false;
    public GameObject closestWay;
    public GameObject[] barreira;
    public bool jaSpawnou = false;
    public Transform firePoint;
    public AudioSource shootSound;
    public bool spawnedObjectisAlive;
    public GameObject spawnObject;
   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);//chamando com pausa
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawn_something)
        {
            if (target == null)
            {
                if (useL)
                {
                    if (lineRenderer.enabled)
                    {
                        lineRenderer.enabled = false;
                    }
                }

                return;//se nao tiver target nao faz nada
            }

            

            if (useL)
            {
                LaserShoot();
            }
            else
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

        else if (spawn_something && spawnObject == null)
        {
            EncontrarObjetoProximo();
            getSAlive(ref spawnObject);
            if (spawnedObjectisAlive == false)
            {
                if (fireCountDown <= 0f)
                {
                   
                    spawnBarreira();
                   
                }

                if (jaSpawnou == false)
                    fireCountDown -= Time.deltaTime;
                else
                {
                    fireCountDown = 3f;
                }



            }

        }
        LockOnTarget();

    }


    void EncontrarObjetoProximo()
    {
        GameObject[] listaDeObjetos = GameObject.FindGameObjectsWithTag("way");

        GameObject objetoMaisProximo = null;
        float menorDistancia = Mathf.Infinity;

        foreach (GameObject objeto in listaDeObjetos)
        {
            if (objeto != null)
            {
                MeshFilter meshFilter = objeto.GetComponent<MeshFilter>();

                if (meshFilter != null && meshFilter.mesh != null)
                {
                    Vector3 centroDoMesh = objeto.transform.TransformPoint(meshFilter.mesh.bounds.center);
                    float distancia = Vector3.Distance(this.transform.position, centroDoMesh);

                    if (distancia < menorDistancia && distancia < range)
                    {
                        menorDistancia = distancia;
                        objetoMaisProximo = objeto;
                    }
                }
            }
        }

        if (objetoMaisProximo != null && spawnedObjectisAlive == false)
        {
            target = objetoMaisProximo.transform;
          
        }
        else
        {
            Debug.LogWarning("Nenhum objeto válido encontrado na lista.");
        }
    }



    void UpdateTarget()
    {
        if(!spawn_something)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemey = null;
            foreach (GameObject enemy in enemies)
            {
                if (enemy.GetComponent<Enemy>().canMoove == true)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distanceToEnemy < shortestDistance)
                    {
                        shortestDistance = distanceToEnemy;
                        nearestEnemey = enemy;
                    }
                }

            }
            if (nearestEnemey != null && shortestDistance <= range)
            {
                target = nearestEnemey.transform;
                targetEnemy = nearestEnemey.GetComponent<Enemy>();
            }
            else
            {
                target = null;
            }
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


    void spawnBarreira()
    {
        if (!jaSpawnou && spawnedObjectisAlive == false)
        {

            jaSpawnou = true;
            int i = Random.Range(0, barreira.Length);
            Quaternion rotacaoSpawnador = transform.rotation;
            Vector3 spawnPosition = target.transform.position + new Vector3(0, target.transform.localScale.y / 2 + barreira[i].transform.localScale.y / 2, 0);
            GameObject objetoSpawnaddo = Instantiate(barreira[i], spawnPosition, rotacaoSpawnador);
            spawnObject = objetoSpawnaddo;

        }
       
    }

    void getSAlive(ref GameObject objeto)
    {
        if (objeto != null)
            spawnedObjectisAlive = true;
        else {
            spawnedObjectisAlive = false;
            jaSpawnou = false;
        }
    }

    void ChangeSpawnou()
    {
        jaSpawnou = false;
    }

}

