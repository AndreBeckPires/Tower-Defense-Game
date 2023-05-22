
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.sTurretPrefab);

    }
    public void PurchaseADifferentTurret()
    {
        Debug.Log("Another  Purchased");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }
}

