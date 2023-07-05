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

    private Enemy enemy;
    void Start()
    {
        audioS = GameObject.Find("dTakenAudio");
        audio = audioS.GetComponent<AudioSource>();
        enemy = GetComponent<Enemy>();
        target = waypoints.points[0];//seleciona o primeiro ponto como targe
    }


    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);//faz a movimentação em direção ao targe

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();//seleciona o proximo lista quando chega ao targe
        }

        enemy.speed = enemy.startSpeed;
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

}
