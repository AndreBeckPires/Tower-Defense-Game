
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update

    public TurretBlueprint standardTurret;
    public TurretBlueprint anotherTurretPrefab;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);

    }
    public void SelectADifferentTurret()
    {
        Debug.Log("Another  Purchased");
        buildManager.SelectTurretToBuild(anotherTurretPrefab);
    }
}

