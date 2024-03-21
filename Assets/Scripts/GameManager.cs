using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverUI;


    public string nextLevel = "Scene2";
    public int levelToUnlock = 2;

    void Start()
    {
        gameOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            return;
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
    }
    
    public void WinLevel()
    {
        Debug.Log("level finished");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(nextLevel);

    }
    public void reset()
    {
        gameOver = false;
    }
}
