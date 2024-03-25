using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aresBuff : MonoBehaviour
{
    public GameObject[] bullets;
    public int bulletsSize;
    public float range = 15f;

    public Image[] vidasCounter;
    public int vidasNUM;
    // Start is called before the first frame update
    void Start()
    {
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        bulletsSize = bullets.Length;

        foreach (GameObject bullet in bullets)
        {
            bullet.GetComponent<Bullet>().damage += 10;
        }
        vidasNUM = 2;
    }

    // Update is called once per frame
    void Update()
    {
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        if (bullets.Length > bulletsSize)
        {
            for (int i = bulletsSize; i < bullets.Length; i++)
            {
                float distancia = Vector3.Distance(this.transform.position, bullets[i].transform.position);
                if (distancia < range)
                {
                    bullets[i].GetComponent<Bullet>().damage += 10;
                }

            }
            bulletsSize = bullets.Length;
        }
        checkVidas();
    }
    void checkVidas()
    {
        if (vidasNUM == 2)
        {
            vidasCounter[0].gameObject.SetActive(true);
            vidasCounter[1].gameObject.SetActive(true);
        }
        if (vidasNUM == 1)
        {
            vidasCounter[0].gameObject.SetActive(true);
            vidasCounter[1].gameObject.SetActive(false);
        }
        if (vidasNUM != 2 && vidasNUM != 1)
        {
            Destroy(gameObject);
        }
    }
}

