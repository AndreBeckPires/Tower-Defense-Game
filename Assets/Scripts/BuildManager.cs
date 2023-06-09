using TMPro;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public TMP_Text TMPText;
    public static BuildManager instance;
    public AudioSource buildTower;


    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one build manager in scene");
            return;
        }
        instance = this; //sempre que come�a o jhogo o build manager vai para  o instance e ai outros podem referenciar o instance, quase como um ponteiro do c++;(singleton patterns)
    }

   // public GameObject sTurretPrefab;
  //  public GameObject anotherTurretPrefab;

    private TurretBlueprint tToBuild;


    public bool CanBuild { 
        get { return tToBuild != null; }
    }
    public bool HasMoney
    {
        get { return PlayerStats.Money >= tToBuild.cost; }
    }
    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < tToBuild.cost)
        {
            Debug.Log("poor");
            return;
        }

        PlayerStats.Money -= tToBuild.cost;
        GameObject turret = (GameObject)Instantiate(tToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        buildTower.Play(0);
        node.turret = turret;
        Debug.Log("Money left " + PlayerStats.Money);
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        tToBuild = turret;
        TMPText.text = "-$" + tToBuild.cost.ToString();
    }
}
