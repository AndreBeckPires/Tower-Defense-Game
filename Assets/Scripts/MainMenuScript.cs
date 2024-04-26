using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{

    public GameObject creditPanel;
    public GameObject commandsPanel;
    public GameObject selectSavePanel;
    public GameObject loadGameButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("levelReached", 1) == 1)
        {
            loadGameButton.SetActive(false);
        }
    }

    public void goPlay()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        selectSavePanel.SetActive(true);
    }


    public void showCredtis()
    {
        creditPanel.SetActive(true);
    }

    public void hideCredtis()
    {
        creditPanel.SetActive(false);
    }

    public void showCommands()
    {
        commandsPanel.SetActive(true);
    }

    public void hideCommands()
    {
        commandsPanel.SetActive(false);
    }


    public void quitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }

    public void newGame()
    {
        PlayerPrefs.SetInt("levelReached", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void loadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void backToMenu()
    {
        selectSavePanel.SetActive(false);
    }

    public void backToMenuPhase()
    {
        SceneManager.LoadScene(0);
    }
}
