using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowNextEnemy : MonoBehaviour
{
    public Sprite minotaur;
    public Sprite centaur;
    public Sprite dragon;
    public Sprite golem;
    Image imagem;
    // Start is called before the first frame update
    void Start()
    {
        imagem = GetComponent<Image>();
        imagem.sprite = minotaur;
        //imagem.sprite = minotaur;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeImage(int i)
    {
        if(i == 0)
        {
            imagem.sprite = minotaur;
        }
        if (i == 1)
        {
            imagem.sprite = centaur;
        }
        if (i == 2)
        {
            imagem.sprite = dragon;
        }
        if(i==3)
        {
            imagem.sprite = golem;
        }
    }
}
