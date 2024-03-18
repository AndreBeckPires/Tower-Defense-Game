using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public Text roundsTxt;
    public GameObject gameMaster;
    void OnEnable()
    {
        roundsTxt.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
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


        this.gameObject.SetActive(false);
        gameMaster.GetComponent<PlayerStats>().reset();
        gameMaster.GetComponent<GameManager>().reset();
        gameMaster.GetComponent<WaveSpawner>().reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
