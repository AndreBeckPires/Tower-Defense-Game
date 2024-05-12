using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeTimeSpeed : MonoBehaviour
{
    public float timeScaleFactor = 2.5f; // Fator de escala de tempo, ajuste conforme necessário

    public bool clicked;

    public Image image; // Referência para o componente Image que você deseja alterar
    public Color newColor = Color.red; // Nova cor que você deseja atribuir à imagem
    public Color originalColor;
    public GameObject button;

    void Start()
    {
        clicked = false;
        if (image == null)
        {
            image = button.GetComponent<Image>();
        }

        // Altera a cor da imagem para a nova cor
        originalColor = image.color;
    }

    void Update()
    {
        if(!clicked)
        {
            image.color = originalColor;
        }
        else
        {
            image.color = newColor;
        }

    }


    public void clicking()
    {
        if(clicked)
        {
            
            ResetTime();
            clicked = false;
        }
       else
        {
            
            AccelerateTime();
            clicked = true;
        }
    }

    public void AccelerateTime()
    {
        Time.timeScale = timeScaleFactor;
    }

    public void ResetTime()
    {
        Time.timeScale = 1f;
    }

    
}
