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

    public GameObject text;
    [Header("Unity")]
    public Image healthBar;
    public GameObject healhBG;
   

    public bool canMoove;
    void Start()
    {
        canMoove = true;
        text.SetActive(false);
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
        canMoove = false;
        PlayerStats.Money += value;
       
        text.SetActive(true);
        healhBG.SetActive(false);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        Invoke("DestroyObject", 0.5f);
        // Destroy(gameObject);

        WaveSpawner.EnemiesAlive--;
    }

    void DestroyObject()
    {
        
        Destroy(gameObject);
    }
}
