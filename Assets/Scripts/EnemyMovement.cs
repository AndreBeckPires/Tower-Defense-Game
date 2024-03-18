using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    public GameObject audioS;
    public AudioSource audio;
    public bool canMoove;
    private Enemy enemy;
    public bool stopped;
    public float thisSpeed;
    public Transform partToRotate;


    void Start()
    {
        canMoove = true;
        audioS = GameObject.Find("dTakenAudio");
        audio = audioS.GetComponent<AudioSource>();
        enemy = GetComponent<Enemy>();
        target = waypoints.points[0];//seleciona o primeiro ponto como targe
        thisSpeed = enemy.startSpeed;
    }


    void Update()
    {
        LockOnTarget();

        canMoove = this.GetComponent<Enemy>().canMoove;
        if(canMoove)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);//faz a movimentação em direção ao targe

            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
               
                GetNextWaypoint();//seleciona o proximo lista quando chega ao targe
            }

            enemy.speed = enemy.startSpeed;
        }
        if (enemy.startSpeed <= 0 && stopped == true)
        {
            stopped = false;
            Invoke("changeSpeed", 3f);
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= waypoints.points.Length - 1)
        {
            audio.Play(0);
            EndPath();
            return;
        }
        wavepointIndex++;
        target = waypoints.points[wavepointIndex];//seleciona o proximo
        

    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);//se chegou no ponto final destroi o objeto
    }

    void changeSpeed()
    {
        enemy.startSpeed = thisSpeed;
    }

    void LockOnTarget()
    {

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * 10).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


    }
}
