using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TelaFinal : MonoBehaviour
{

    public GameObject ui;
    public GameObject GameMaster;
    public GameObject[] botoes;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(ui.activeSelf)
        {
            foreach (GameObject botao in botoes)
            {
                botao.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject botao in botoes)
            {
                botao.SetActive(false);
            }
        }
    }
}
