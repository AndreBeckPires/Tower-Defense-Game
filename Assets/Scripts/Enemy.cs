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
    public GameObject meshbody;


    public bool jaRendeu;
    public bool canMoove;

    public GameObject destroyEffect;
    void Start()
    {
        jaRendeu = false;
         canMoove = true;
        text.SetActive(false);
        health = startHealth;
        speed = startSpeed;
        text.GetComponent<Text>().text =  "+" + value.ToString();
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
        if(!jaRendeu)
        {
            PlayerStats.Money += value;
            jaRendeu = true;
        }
     
        
        text.SetActive(true);
        healhBG.SetActive(false);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(meshbody);
        Instantiate(destroyEffect, transform.position + Vector3.up * 2.0f, transform.rotation);
        Invoke("DestroyObject", 0.5f);
       
        // Destroy(gameObject);

        WaveSpawner.EnemiesAlive--;
    }

    void DestroyObject()
    {
       
        Destroy(gameObject);
    }
}
