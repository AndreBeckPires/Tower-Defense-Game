using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{

    public GameObject creditPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }


    public void showCredtis()
    {
        creditPanel.SetActive(true);
    }

    public void hideCredtis()
    {
        creditPanel.SetActive(false);
    }


    public void quitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
}
