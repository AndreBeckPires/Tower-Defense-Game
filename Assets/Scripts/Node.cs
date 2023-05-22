
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 pOffset;

    private GameObject turret;

    private Renderer rend;
    private Color sColor;

    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        sColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        if(turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        //build turret
        GameObject tToBuild = buildManager.GetTurretToBuild();
       turret = (GameObject)Instantiate(tToBuild, transform.position + pOffset, transform.rotation);
    }


    void OnMouseEnter()
    {

        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }
    
    void OnMouseExit()
    {
        rend.material.color = sColor;
    }
}
