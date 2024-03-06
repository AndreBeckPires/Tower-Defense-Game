using UnityEngine;

public class CursorHover : MonoBehaviour
{

    public GameObject objetoASpawnar;
    public GameObject objetoSpawnado;
    public GameObject shop;
    public Color corPossivel;
    public Color corImpossivel;
    public float range = 30f;
    public GameObject showRange;
    public GameObject shownRange;
    public Material novoMaterial;
    BuildManager buildManager;
  
    void Start() 
    {

      
        buildManager = BuildManager.instance;
        shop = GameObject.Find("Shop");
     
      
    }
    void Update()
    {
    }

    void OnMouseEnter()
    {

      

        showRange.transform.localScale = new Vector3(buildManager.getRange() * 2f, 1f, buildManager.getRange() * 2f);
     
        if (buildManager.HasMoney())
        {
            novoMaterial = objetoASpawnar.GetComponent<Renderer>().sharedMaterial;
            novoMaterial.color = corPossivel;
            objetoASpawnar.GetComponent<Renderer>().sharedMaterial = novoMaterial;
        }
        else
        {
           novoMaterial = objetoASpawnar.GetComponent<Renderer>().sharedMaterial;
            novoMaterial.color = corImpossivel;
            objetoASpawnar.GetComponent<Renderer>().sharedMaterial = novoMaterial;
        }

        if (shop.GetComponent<Shop>().getComprou())
        {
            // Este método é chamado quando o mouse entra no objeto
           
            Vector3 posicaoReferencia = transform.position;

            // Adiciona um offset à posição de referência se desejado (opcional)
            // Por exemplo, para spawnar o objeto acima do objeto de referência:
            // posicaoReferencia += new Vector3(0, 1, 0);

            // Spawna o objeto na posição de referência
            objetoSpawnado = Instantiate(objetoASpawnar, posicaoReferencia, Quaternion.identity);
            shownRange = Instantiate(showRange, posicaoReferencia, Quaternion.identity);
        }

    }

    void OnMouseExit()
    {
        // Este método é chamado quando o mouse sai do objeto
       
        if (objetoSpawnado != null)
        {
            Destroy(objetoSpawnado);
           Destroy(shownRange);
        }
    }

}


