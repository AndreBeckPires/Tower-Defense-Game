
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;
    public int health = 100;
    public int value = 50;

    void Start()
    {
        target = waypoints.points[0];//seleciona o primeiro ponto como targe
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);//faz a movimentação em direção ao targe

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();//seleciona o proximo lista quando chega ao targe
        }
    }
    
    void GetNextWaypoint()
    {
        if(wavepointIndex >= waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = waypoints.points[wavepointIndex];//seleciona o proximo
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);//se chegou no ponto final destroi o objeto
    }
}
