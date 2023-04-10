
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = waypoints.points[0];//seleciona o primeiro ponto como targe
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
            Destroy(gameObject);//se chegou no ponto final destroi o objeto
            return;
        }
        wavepointIndex++;
        target = waypoints.points[wavepointIndex];//seleciona o proximo
    }
}
