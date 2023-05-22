
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one build manager in scene");
            return;
        }
        instance = this; //sempre que começa o jhogo o build manager vai para  o instance e ai outros podem referenciar o instance, quase como um ponteiro do c++;(singleton patterns)
    }

    public GameObject sTurretPrefab;
    public GameObject anotherTurretPrefab;

    private GameObject tToBuild;



    public GameObject GetTurretToBuild()
    {
        return tToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        tToBuild = turret;
    }
}
