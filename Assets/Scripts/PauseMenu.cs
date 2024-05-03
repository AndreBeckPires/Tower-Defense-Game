using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{

    public GameObject ui;
    public GameObject listaDeInimigos;
    public GameObject GameMaster;
    public GameObject[] botoes;

    public GameObject canvasInfobot;
    public GameObject canvasInfoTop;
    public GameObject inimigosButton;

    public GameObject startScreen;

    public bool listaOpen = false;
    public GameObject ComTag;

    void Start()
    {
        ComTag = GameObject.FindGameObjectWithTag("SHOP");
    }


   void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            foreach (GameObject botao in botoes)
            {
                botao.SetActive(true);
            }
            Toggle();
        }
        if (ui.activeSelf || startScreen.activeSelf)
        {
            inimigosButton.SetActive(false);
            canvasInfobot.SetActive(false);
            canvasInfoTop.SetActive(false);
            GameObject[] objetosComTag = GameObject.FindGameObjectsWithTag("WAVESICON");
            foreach (GameObject objeto in objetosComTag)
            {
                // Fa�a o que voc� precisa com cada objeto encontrado aqui
                objeto.GetComponent<Image>().enabled = false;
            }
            
            ComTag.SetActive(false);
        }
        else
        {
            canvasInfobot.SetActive(true);
            canvasInfoTop.SetActive(true);
            inimigosButton.SetActive(true);
            GameObject[] objetosComTag = GameObject.FindGameObjectsWithTag("WAVESICON");
            foreach (GameObject objeto in objetosComTag)
            {
                // Fa�a o que voc� precisa com cada objeto encontrado aqui
                objeto.GetComponent<Image>().enabled = true;
            }
           
            ComTag.SetActive(true);
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


        if (ui.activeSelf)
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


    public void ListaDeInimigos()
    {
        listaDeInimigos.SetActive(true);
        foreach(GameObject botao in botoes)
        {
            botao.SetActive(false);
        }
        Toggle();
       
        
        
    }
    public void CloseListaDeInimigos()
    {
        foreach (GameObject botao in botoes)
        {
            botao.SetActive(true);
        }
        listaDeInimigos.SetActive(false);
        Toggle();
    }
    
    public void quitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }

}
