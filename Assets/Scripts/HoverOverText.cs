using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
public class HoverOverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
     public GameObject HoverPanel;
     public TMP_Text TMPText;
    private Button button;
    public float value;
    [TextArea(3, 10)]
    public string HOVERTEXT;

    bool mouseOver;

    void Start()
    {
        button = GetComponent<Button>();
        mouseOver = false;
    }

    void Update()
    {
        if(mouseOver == true)
        {
            if (PlayerStats.Money < value)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }
        else
        {
            button.interactable = true;
        }
    }
 
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        mouseOver = true;
        TMPText.text = HOVERTEXT;
        HoverPanel.SetActive(true);
        if(PlayerStats.Money < value)
        {
            button.interactable = false;
        }
    }


    public void OnPointerExit(PointerEventData pointerEventData)
    {
        mouseOver = false;
        button.interactable = true;
        HoverPanel.SetActive(false);
    }
}

