using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerBuff : MonoBehaviour
{

    public GameObject[] towers;
    public int towersSize;
    // Start is called before the first frame update
    void Start()
    {
        towers = GameObject.FindGameObjectsWithTag("Tower");
        towersSize = towers.Length;

        foreach(GameObject tower in towers)
        {
            tower.GetComponent<Turret>().fireRate += 0.2f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        towers = GameObject.FindGameObjectsWithTag("Tower");
        if (towers.Length > towersSize)
        {
            for (int i = towersSize; i < towers.Length; i++){
                towers[i].GetComponent<Turret>().fireRate += 0.2f;
            }
            towersSize = towers.Length;
        }
    }
}
