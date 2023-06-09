
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("BluePrints")]
    public TurretBlueprint standardTurret;
    public TurretBlueprint anotherTurretPrefab;
    public TurretBlueprint tower3;
    public TurretBlueprint t4;
    public TurretBlueprint tSteal;

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
    public void SelectT3()
    {
        buildManager.SelectTurretToBuild(tower3);
    }

    public void SelectT4()
    {
        buildManager.SelectTurretToBuild(t4);
    }

    public void SelectSteal()
    {
        buildManager.SelectTurretToBuild(tSteal);
    }
}

