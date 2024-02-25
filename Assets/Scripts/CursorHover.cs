using UnityEngine;

public class CursorHover : MonoBehaviour
{

    public GameObject objetoASpawnar;
    public GameObject objetoSpawnado;
    public GameObject shop;
    public Color corPossivel;
    public Color corImpossivel;


    BuildManager buildManager;

    void Start() 
    {
        buildManager = BuildManager.instance;
        shop = GameObject.Find("Shop");
     
      
    }
    void Update()
    {
        if (buildManager.HasMoney())
        {
            Material novoMaterial = new Material(objetoASpawnar.GetComponent<Renderer>().sharedMaterial);
            novoMaterial.color = corPossivel;
            objetoASpawnar.GetComponent<Renderer>().sharedMaterial = novoMaterial;
        }
        else
        {
            Material novoMaterial = new Material(objetoASpawnar.GetComponent<Renderer>().sharedMaterial);
            novoMaterial.color = corImpossivel;
            objetoASpawnar.GetComponent<Renderer>().sharedMaterial = novoMaterial;
        }


    }

    void OnMouseEnter()
    {

     

        if (shop.GetComponent<Shop>().getComprou())
        {
            // Este método é chamado quando o mouse entra no objeto
            Debug.Log("Mouse entrou no objeto: " + gameObject.name);
            Vector3 posicaoReferencia = transform.position;

            // Adiciona um offset à posição de referência se desejado (opcional)
            // Por exemplo, para spawnar o objeto acima do objeto de referência:
            // posicaoReferencia += new Vector3(0, 1, 0);

            // Spawna o objeto na posição de referência
            objetoSpawnado = Instantiate(objetoASpawnar, posicaoReferencia, Quaternion.identity);
        }

    }

    void OnMouseExit()
    {
        // Este método é chamado quando o mouse sai do objeto
        Debug.Log("Mouse saiu do objeto: " + gameObject.name);
        if (objetoSpawnado != null)
        {
            Destroy(objetoSpawnado);
        }
    }

}


