
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 pOffset;

    private GameObject turret;

    private Renderer rend;
    private Color sColor;
    void Start()
    {
        rend = GetComponent<Renderer>();
        sColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        //build turret
        GameObject tToBuild = BuildManager.instance.GetTurretToBuild();
       turret = (GameObject)Instantiate(tToBuild, transform.position + pOffset, transform.rotation);
    }


    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    
    void OnMouseExit()
    {
        rend.material.color = sColor;
    }
}
