using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject ui;
    public GameObject GameMaster;
   void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        if(ui.activeSelf)
        {
            ui.SetActive(false);
        }
        else
        {
            ui.SetActive(true);
        }
        
        if(ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        if(!ui.activeSelf)
        {
            Time.timeScale = 1.0f;
        }

    }

    public void Retry()
    {
        Toggle();
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Tower");

        foreach (GameObject obj in objectsWithTag)
        {
            // Do something with obj
            Destroy(obj);
        }
        GameObject[] objectsWithTag2 = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in objectsWithTag2)
        {
            // Do something with obj
            Destroy(obj);
        }

        GameMaster.GetComponent<PlayerStats>().reset();
        GameMaster.GetComponent<WaveSpawner>().reset();
     
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        GameMaster.GetComponent<PlayerStats>().reset();
        GameMaster.GetComponent<WaveSpawner>().reset();
        SceneManager.LoadScene(0);
    }
    
    public void quitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }

}
