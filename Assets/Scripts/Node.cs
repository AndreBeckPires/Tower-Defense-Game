
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 pOffset;

    [Header("Optional")]
    public  GameObject turret;

    private Renderer rend;
    private Color sColor;

    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        sColor = rend.material.color;
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
    }


    void OnMouseEnter()
    {

        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
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
