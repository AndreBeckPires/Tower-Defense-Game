using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barreira : MonoBehaviour
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
        // Verifica se a colisão ocorreu com um objeto específico
        if (collision.gameObject.tag == "Enemy")
        {
            // Faça algo quando houver colisão com o objeto desejado
            Debug.Log("Colisão com o objeto desejado!");
            collision.gameObject.GetComponent<Enemy>().startSpeed = 0;
            collision.gameObject.GetComponent<EnemyMovement>().stopped = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<BoxCollider>().enabled = false;
            DestroyObject();
        }
    }


    void DestroyObject()
    {
        Destroy(gameObject, 3f);
    }
}
