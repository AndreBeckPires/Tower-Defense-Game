using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeTimeSpeed : MonoBehaviour
{
    public float timeScaleFactor = 2.5f; // Fator de escala de tempo, ajuste conforme necess�rio

    public bool clicked;

    public Image image; // Refer�ncia para o componente Image que voc� deseja alterar
    public Color newColor = Color.red; // Nova cor que voc� deseja atribuir � imagem
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
