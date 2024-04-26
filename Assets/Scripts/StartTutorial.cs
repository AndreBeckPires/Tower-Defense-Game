using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class StartTutorial : MonoBehaviour
{
    public GameObject ui;
    public GameObject pause;
    public TMP_Text TMPText;
    public Text texto;
    public GameObject listaUI;

    public GameObject canvasInfobot;
    public GameObject canvasInfoTop;
    public GameObject inimigosButton;
    public GameObject shop;
   


    [TextArea(3, 10)]
    public string HOVERTEXT;
    // Start is called before the first frame update
    void Start()
    {
        texto.text = HOVERTEXT;

    }

    // Update is called once per frame
    public void close()
    {
        ui.SetActive(false);
     
    }

    void Update()
    {
        if (ui.activeSelf && !pause.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else if(!ui.activeSelf && !pause.activeSelf)
        {
            Time.timeScale = 1.0f;
        }

      
    }
}
