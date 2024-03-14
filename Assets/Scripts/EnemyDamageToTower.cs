using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageToTower : MonoBehaviour
{
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
            collision.gameObject.GetComponent<Turret>().vidasNUM -= 1;
        }
    }
}
