using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public Button[] lButtons;

    void Start()
    {
       //PlayerPrefs.SetInt("levelReached", 1);

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
 

        for (int i = 0; i < lButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            {
                lButtons[i].interactable = false;
                lButtons[i].GetComponent<Image>().color = Color.grey;
            }

        }
    }

   public void Select(int index)
    {
        SceneManager.LoadScene(index);
    }
}
