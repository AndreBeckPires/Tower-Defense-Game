using UnityEngine;

public class CursorHover : MonoBehaviour
{

    public GameObject objetoASpawnar;
    public GameObject objetoSpawnado;
    public GameObject shop;

    void Start() 
    {
        shop = GameObject.Find("Shop");
    }
    void Update()
    {

    }

    void OnMouseEnter()
    {
        if (shop.GetComponent<Shop>().getComprou())
        {
            // Este m�todo � chamado quando o mouse entra no objeto
            Debug.Log("Mouse entrou no objeto: " + gameObject.name);
            Vector3 posicaoReferencia = transform.position;

            // Adiciona um offset � posi��o de refer�ncia se desejado (opcional)
            // Por exemplo, para spawnar o objeto acima do objeto de refer�ncia:
            // posicaoReferencia += new Vector3(0, 1, 0);

            // Spawna o objeto na posi��o de refer�ncia
            objetoSpawnado = Instantiate(objetoASpawnar, posicaoReferencia, Quaternion.identity);
        }

    }

    void OnMouseExit()
    {
        // Este m�todo � chamado quando o mouse sai do objeto
        Debug.Log("Mouse saiu do objeto: " + gameObject.name);
        if (objetoSpawnado != null)
        {
            Destroy(objetoSpawnado);
        }
    }

}


