using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public Text LivesText;
    public GameObject[] vidasicons;
    // Update is called once per frame
    void Update()
    {
        LivesText.text = PlayerStats.Lives + " LIVES";
        if(PlayerStats.Lives == 2)
        {
            
        }
        if (PlayerStats.Lives == 1)
        {
            Destroy(vidasicons[1]);
        }
        if (PlayerStats.Lives <= 0)
        {
            Destroy(vidasicons[0]);
        }
    }
}
