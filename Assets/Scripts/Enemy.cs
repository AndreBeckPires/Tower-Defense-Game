using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;
    
    
    public float startHealth = 100;
    public float health;
    public int value = 50;

    [Header("Unity")]
    public Image healthBar;
  

    void Start()
    {
        health = startHealth;
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow (float amount)
    {
        speed = startSpeed * (1f - amount);
    }

    void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

   
}
