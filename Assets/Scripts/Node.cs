
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.EventSystems;
using TMPro;




public class Node : MonoBehaviour
{
  
    public Vector3 pOffset;

    public GameObject goldText;

    [Header("Optional")]
    public  GameObject turret;

    private Renderer rend;


    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
       
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + pOffset;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if(turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        buildManager.BuildTurretOn(this);
        goldText.SetActive(true);
    }


 
    
 
}
