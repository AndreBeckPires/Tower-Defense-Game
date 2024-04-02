using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageToTower : MonoBehaviour
{
    public Turret script;
    public towerBuff scriptT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica se a colis�o ocorreu com um objeto espec�fico
        if (collision.gameObject.tag == "Tower")
        {
            // Fa�a algo quando houver colis�o com o objeto desejado
            Debug.Log("Colis�o com o objeto desejado!");
            script = collision.gameObject.GetComponent<Turret>();
            scriptT= collision.gameObject.GetComponent<towerBuff>();
            if (script != null && script.enabled)
            {
                collision.gameObject.GetComponent<Turret>().vidasNUM -= 1;
            }
            else if((scriptT != null && scriptT.enabled))
            {
                collision.gameObject.GetComponent<towerBuff>().vidasNUM -= 1;
               
            }
            else
            {
                collision.gameObject.GetComponent<aresBuff>().vidasNUM -= 1;
            }


         
        }
    }
}
