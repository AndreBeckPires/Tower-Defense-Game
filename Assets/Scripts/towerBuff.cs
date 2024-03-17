using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class towerBuff : MonoBehaviour
{

    public GameObject[] towers;
    public int towersSize;
    public float range = 15f;

    public Image[] vidasCounter;
    public int vidasNUM;
    // Start is called before the first frame update
    void Start()
    {
        towers = GameObject.FindGameObjectsWithTag("Tower");
        towersSize = towers.Length;

        foreach(GameObject tower in towers)
        {
            tower.GetComponent<Turret>().fireRate += 0.2f;
        }
        vidasNUM = 2;
    }

    // Update is called once per frame
    void Update()
    {
        towers = GameObject.FindGameObjectsWithTag("Tower");
        if (towers.Length > towersSize)
        {
            for (int i = towersSize; i < towers.Length; i++){
                float distancia = Vector3.Distance(this.transform.position, towers[i].transform.position);
                if(distancia < range)
                {
                    towers[i].GetComponent<Turret>().fireRate += 0.2f;
                }
               
            }
            towersSize = towers.Length;
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
